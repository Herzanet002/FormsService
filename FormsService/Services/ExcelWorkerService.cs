using FormsService.DAL.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;

namespace FormsService.API.Services
{
    public class ExcelWorkerService<T> where T : Person
    {
        public async Task CreateExcelReport(DateOnly dateNow, IReadOnlyList<DateTime> daysInMonth,
            IEnumerable<T> persons, string outputPath)
        {
            using var package = new ExcelPackage();
            var sheetTitle = dateNow.ToString("MMMM yyyy", CultureInfo.CurrentUICulture);
            var worksheet = package.Workbook.Worksheets.Add(sheetTitle);
            worksheet.Cells[1, 1].Value = sheetTitle;

            var daysInMonthCount = daysInMonth.Count;

            FillLeftColumnWithDates(daysInMonth, worksheet);
            var personsEndCol = FillPersonsRow(dateNow, persons, worksheet);

            FillLabels(worksheet, personsEndCol, daysInMonthCount);

            SetFormulaToSumForDayRow(daysInMonthCount, worksheet, personsEndCol);

            SetFormulaToConcretePersonColumn(worksheet, daysInMonthCount);

            SetSummaryLabels(worksheet);

            WorksheetStyleSetup(worksheet, personsEndCol + 3, daysInMonthCount + 3);

            await package.SaveAsAsync(new FileInfo(outputPath));
        }

        protected virtual void SetSummaryLabels(ExcelWorksheet worksheet)
        {
            var endRow = worksheet.Dimension.End;
            var last3Cells = worksheet.Cells[endRow.Row + 1, endRow.Column - 2, endRow.Row + 1, endRow.Column - 1];
            last3Cells.Merge = true;
            last3Cells.Style.Font.Bold = true;
            last3Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            last3Cells.Style.Fill.BackgroundColor.SetColor(Color.Plum);
            last3Cells.Value = "Итого со скидкой:";
            var range = worksheet.Cells[endRow.Row - 1, endRow.Column - 1, endRow.Row - 1, endRow.Column];

            worksheet.Cells[endRow.Row + 1, endRow.Column].Style.Font.Bold = true;
            worksheet.Cells[endRow.Row + 1, endRow.Column].Formula = $"SUM({range})";
        }

        protected virtual void SetFormulaToConcretePersonColumn(ExcelWorksheet worksheet, int daysInMonthCount)
        {
            for (var col = 2; col <= worksheet.Dimension.End.Column; col++)
            {
                var range = worksheet.Cells[2, col, daysInMonthCount + 1, col].Address;
                if (worksheet.Cells[1, col].Value == null) continue;
                worksheet.Cells[daysInMonthCount + 2, col].Formula = $"=SUM({range})";
                worksheet.Cells[daysInMonthCount + 2, col].Style.Font.Bold = true;
                if (col < worksheet.Dimension.End.Column - 3)
                    worksheet.Cells[daysInMonthCount + 3, col].Formula = $"=SUM({range}) - SUM({range})/10";
            }
        }

        protected virtual void SetFormulaToSumForDayRow(int daysInMonthCount, ExcelWorksheet worksheet, int personsEndCol)
        {
            for (var row = 2; row <= daysInMonthCount + 1; row++)
            {
                var range = worksheet.Cells[row, 2, row, personsEndCol].Address; //BN-?N
                worksheet.Cells[row, personsEndCol + 1].Formula = $"=SUM({range})";
                worksheet.Cells[row, personsEndCol + 2].Formula = $"=SUM({range}) - SUM({range})/10";
            }
        }

        protected virtual void FillLabels(ExcelWorksheet worksheet, int personsEndCol, int daysInMonthCount)
        {
            worksheet.Cells[1, personsEndCol + 1].Value = "Сумма за день";
            worksheet.Cells[1, personsEndCol + 2].Value = "Со скидкой";
            worksheet.Cells[1, personsEndCol + 3].Value = "Доставка";

            worksheet.Cells[daysInMonthCount + 2, 1].Value = "Итого";
            worksheet.Cells[daysInMonthCount + 2, 1].Style.Font.Bold = true;
            worksheet.Cells[daysInMonthCount + 3, 1].Value = "Со скидкой:";
        }

        protected virtual int FillPersonsRow(DateOnly dateNow, IEnumerable<T> persons, ExcelWorksheet worksheet)
        {
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

            return personsEndCol;
        }

        protected virtual void FillLeftColumnWithDates(IReadOnlyList<DateTime> daysInMonth, ExcelWorksheet worksheet)
        {
            for (var row = 0; row < daysInMonth.Count; row++)
            {
                var day = daysInMonth[row];
                worksheet.Cells[row + 2, 1].Value = day.ToString("dd MM yyyy");
            }
        }

        public void WorksheetStyleSetup(ExcelWorksheet worksheet, int endColumn, int endRow)
        {
            var worksheetCells = worksheet.Cells[1, 1, endRow, endColumn]; // рабочая область

            worksheetCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheetCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            worksheetCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            worksheetCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Cells.AutoFitColumns();
        }
    }
}