using Application.Interfaces.Repositories;
using Domain.Entities;
using FormsService.API.Services;
using FormsService.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> RequestMonthReport(int month, int year)
    {
        if (month == 0 && year == 0)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
        }

        if (month == 0 || year == 0) return BadRequest();

        var outputPath = Path.Combine(Environment.CurrentDirectory, @"Reports\Report.xlsx");
        var date = new DateOnly(year, month, 1);

        var daysInMonth = GetDaysInMonth(date);
        await _dishOrderRepository.GetAllWithInclude(p => p.Order, q => q.Order.Person);
        var employees = await _personsRepository.GetAllWithInclude(x => x.Orders!);

        using var scope = _serviceProvider.CreateScope();
        var excelWorker = scope.ServiceProvider.GetService<ExcelWorkerService<Person>>()
                          ?? throw new NullReferenceException(nameof(ExcelWorkerService<Person>));

        await excelWorker.CreateExcelReport(date, daysInMonth, employees, outputPath);

        return Ok();
    }

    private static List<DateTime> GetDaysInMonth(DateOnly dateNow)
    {
        return Enumerable.Range(1, DateTime.DaysInMonth(dateNow.Year, dateNow.Month))
            .Select(day => new DateTime(dateNow.Year, dateNow.Month, day))
            .ToList();
    }
}