using Domain.Entities;
using Domain.Enums;
using FormsService.API.Services.Interfaces;
using TemplateEngine.Docx;

namespace FormsService.API.Services;

public class WordWorkerServiceService<T> : IWordWorkerService<T> where T : Order
{
    public Content CreateReport(IEnumerable<T> orders, DateOnly reportDate, string outputPath)
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

        var valuesToFill = new Content(tableContent);
        valuesToFill.Fields.Add(new FieldContent("ReportDate", reportDate.ToShortDateString()));
        return valuesToFill;
    }

    public TemplateProcessor SaveCreatedReport(Content valuesToFill, string outputPath)
    {
        using var outputDocument = new TemplateProcessor(outputPath)
            .SetRemoveContentControls(true);
        outputDocument.FillContent(valuesToFill);
        outputDocument.SaveChanges();
        return outputDocument;
    }
}