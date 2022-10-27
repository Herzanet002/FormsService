using System.Drawing;
using System.Globalization;
using FormsService.API.Reports;
using FormsService.API.Reports.Services.Interfaces;
using FormsService.DAL.Entities;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace FormsService.API.Controllers;

[ApiController]
[Route("/api/[controller]/")]
public class ReportController : Controller
{
    private readonly IRepository<DishOrder> _dishOrderRepository;
    private readonly IRepository<Order> _ordersRepository;
    private readonly IRepository<Person> _personsRepository;
    private readonly IServiceProvider _serviceProvider;

    public ReportController(IRepository<Order> ordersRepository,
        IRepository<DishOrder> dishOrderRepository,
        IRepository<Person> personsRepository,
        IServiceProvider serviceProvider)
    {
        _ordersRepository = ordersRepository;
        _dishOrderRepository = dishOrderRepository;
        _personsRepository = personsRepository;
        _serviceProvider = serviceProvider;
    }

    [HttpGet("DateReport")]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
    public async Task<IActionResult> RequestDateReport(int day, int month, int year)
    {
        var inputTemplatePath = Path.Combine(Environment.CurrentDirectory, @"Reports\InputDoc.docx");
        var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\OutputDoc.docx");

        if (!System.IO.File.Exists(inputTemplatePath)) return BadRequest();

        System.IO.File.Delete(outputPath);
        System.IO.File.Copy(inputTemplatePath, outputPath);
        var date = new DateOnly(year, month, day);
       
        var orders = (await _ordersRepository.GetAllWithInclude(order => order.Person,
            order => order.Dishes)).Where(order => order.DateForming.Date == date.ToDateTime(TimeOnly.MinValue));

        using var scope = _serviceProvider.CreateScope();
        var wordWorkerService = scope.ServiceProvider.GetService<IWordWorkerService<Order>>()
                                ?? throw new NullReferenceException(nameof(IWordWorkerService<Order>));
        var docContent = wordWorkerService.CreateReport(orders, outputPath);
        if (docContent is null) return BadRequest();
        wordWorkerService.SaveCreatedReport(docContent, outputPath);
        return File(await System.IO.File.ReadAllBytesAsync(outputPath), "application/octet-stream", "Report.docx");
    }

    [HttpGet("MonthReport")]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
    public async Task<IActionResult> RequestMonthReport()
    {
        var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\Report.xlsx");
        var dateNow = DateTime.Now;
        var daysInMonth = GetDaysInMonth(dateNow);
        await CreateExcelReport(dateNow, daysInMonth, outputPath);

        return Ok();
    }

    private async Task CreateExcelReport(DateTime dateNow, IReadOnlyList<DateTime> daysInMonth, string outputPath)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Месячный отчет");
        worksheet.Cells[1, 1].Value = dateNow.ToString("MMMM yyyy", CultureInfo.CurrentUICulture);

        for (var row = 0; row < daysInMonth.Count; row++)
        {
            var day = daysInMonth[row];
            worksheet.Cells[row + 2, 1].Value = day.ToString("dd MM yyyy");
        }

        await _dishOrderRepository.GetAllWithInclude(p => p.Order, q => q.Order.Person);
        var employees = await _personsRepository.GetAllWithInclude(x => x.Orders!);
        var persons = employees as List<Person> ?? employees.ToList();
        var personsEndCol = 2;
        foreach (var person in persons)
        {
            var personOrders = person.Orders;
            if (personOrders is null || personOrders.Count == 0 ||
                personOrders.All(o => o.DateForming.Month != dateNow.Month)) continue;
            worksheet.Cells[1, personsEndCol].Value = person.Name;
            foreach (var order in personOrders.Where(o => o.DateForming.Month == dateNow.Month))
            {
                var cellCol = worksheet.Cells.FirstOrDefault(c => c.Value.ToString() == order.Person.Name);
                var cellRow = worksheet.Cells.FirstOrDefault(c =>
                    c.Value.ToString() == order.DateForming.ToString("dd MM yyyy"));
                if (order.DishOrders is null) continue;
                var totalAmountOfTheOrder = order.DishOrders.Sum(dishOrder => dishOrder.Price);
                if (cellCol != null && cellRow != null)
                    worksheet.Cells[cellCol.ToString()[..1] + cellRow.ToString()[1..]].Value = totalAmountOfTheOrder;
            }

            personsEndCol++;
        }

        worksheet.Cells[1, personsEndCol + 1].Value = "Сумма за день";
        worksheet.Cells[1, personsEndCol + 2].Value = "Со скидкой";
        worksheet.Cells[1, personsEndCol + 3].Value = "Доставка";

        worksheet.Cells[daysInMonth.Count + 2, 1].Value = "Итого";
        worksheet.Cells[daysInMonth.Count + 2, 1].Style.Font.Bold = true;
        worksheet.Cells[daysInMonth.Count + 3, 1].Value = "Со скидкой:";

        var worksheetCells = worksheet.Cells[1, 1, daysInMonth.Count + 3, personsEndCol + 3]; // рабочая область

        for (var row = 2; row <= daysInMonth.Count + 1; row++)
        {
            var range = worksheet.Cells[row, 2, row, personsEndCol].Address; //BN-?N
            worksheet.Cells[row, personsEndCol + 1].Formula = $"=SUM({range})";
            worksheet.Cells[row, personsEndCol + 2].Formula = $"=SUM({range}) - SUM({range})/10";
        }

        for (var col = 2; col <= worksheet.Dimension.End.Column; col++)
        {
            var range = worksheet.Cells[2, col, daysInMonth.Count + 1, col].Address;
            if (worksheet.Cells[1, col].Value == null) continue;
            worksheet.Cells[daysInMonth.Count + 2, col].Formula = $"=SUM({range})";
            worksheet.Cells[daysInMonth.Count + 2, col].Style.Font.Bold = true;
            if (col < worksheet.Dimension.End.Column - 3)
                worksheet.Cells[daysInMonth.Count + 3, col].Formula = $"=SUM({range}) - SUM({range})/10";
        }

        var endRow = worksheet.Dimension.End;
        var last3Cells = worksheet.Cells[endRow.Row + 1, endRow.Column - 2, endRow.Row + 1, endRow.Column - 1];
        last3Cells.Merge = true;
        last3Cells.Style.Font.Bold = true;
        last3Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
        last3Cells.Style.Fill.BackgroundColor.SetColor(Color.Plum);
        last3Cells.Value = "Итого со скидкой:";
        var rs = worksheet.Cells[endRow.Row - 1, endRow.Column - 1];
        var del = worksheet.Cells[endRow.Row - 1, endRow.Column];

        worksheet.Cells[endRow.Row + 1, endRow.Column].Style.Font.Bold = true;
        worksheet.Cells[endRow.Row + 1, endRow.Column].Formula = $"SUM({rs}:{del})";

        WorksheetStyleSetup(worksheetCells, worksheet);

        await package.SaveAsAsync(new FileInfo(outputPath));
    }

    private static void WorksheetStyleSetup(ExcelRangeBase worksheetCells, ExcelWorksheet worksheet)
    {
        worksheetCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        worksheetCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        worksheetCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        worksheetCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        worksheet.Cells.AutoFitColumns();
    }

    private static List<DateTime> GetDaysInMonth(DateTime dateNow)
    {
        return Enumerable.Range(1, DateTime.DaysInMonth(dateNow.Year, dateNow.Month))
            .Select(day => new DateTime(dateNow.Year, dateNow.Month, day))
            .ToList();
    }
}