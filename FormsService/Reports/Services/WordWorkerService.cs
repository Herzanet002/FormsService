using FormsService.DAL.Entities;
using TemplateEngine.Docx;

namespace FormsService.API.Reports;

public class WordWorkerServiceService<T> : IWordWorkerService<T> where T : Order
{
    public Content CreateReport(IEnumerable<T> orders, string outputPath)
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
        valuesToFill.Fields.Add(new FieldContent("ReportDate", DateTime.Now.Date.ToShortDateString()));
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

public interface IWordWorkerService<in TEntity> 
{
    Content? CreateReport(IEnumerable<TEntity> collection, string outputPath);
    TemplateProcessor SaveCreatedReport(Content valuesToFill, string outputPath);
}