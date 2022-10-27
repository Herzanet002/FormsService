using TemplateEngine.Docx;

namespace FormsService.API.Reports;

public interface IWordWorkerService<in TEntity> 
{
    Content? CreateReport(IEnumerable<TEntity> collection, string outputPath);
    TemplateProcessor SaveCreatedReport(Content valuesToFill, string outputPath);
}