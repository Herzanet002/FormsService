using TemplateEngine.Docx;

namespace FormsService.API.Services.Interfaces;

public interface IWordWorkerService<in TEntity>
{
    Content? CreateReport(IEnumerable<TEntity> collection, DateOnly reportDate, string outputPath);

    TemplateProcessor SaveCreatedReport(Content valuesToFill, string outputPath);
}