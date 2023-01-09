using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Enums;
using TemplateEngine.Docx;

namespace Infrastructure.Services;

public class WordWorkerServiceService<T> : IWordWorkerService<T> where T : Order
{
    private Content _valuesToFill;

    public WordWorkerServiceService()
    {
        _valuesToFill = new Content();
    }

    public IWordWorkerService<T> CreateReport(IEnumerable<T> orders, DateOnly reportDate)
    {
        var tableContent = new TableContent("OrdersTable");

        var currentOrderNumber = 1;

        foreach (var order in orders)
        {
            tableContent.AddRow(new FieldContent("Number", currentOrderNumber.ToString()),
                new FieldContent("Name", order.Person.Name),
                new FieldContent("YesNo", order.Location == Location.WithMe ? "Да" : "Нет"),
                new FieldContent("Dishes", string.Join(".\n", order.Dishes.Select(x => x.Name))),
                new FieldContent("VisitTime", "С 12ч. до 13ч."));
            currentOrderNumber++;
        }

        _valuesToFill = new Content(tableContent);
        _valuesToFill.Fields.Add(new FieldContent("ReportDate", reportDate.ToShortDateString()));
        return this;
    }

    public void SaveReport(string outputPath)
    {
        using var outputDocument = new TemplateProcessor(outputPath)
            .SetRemoveContentControls(true);
        outputDocument.FillContent(_valuesToFill);
        outputDocument.SaveChanges();
    }
}