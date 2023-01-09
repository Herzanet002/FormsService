namespace Application.Interfaces.Services;

public interface IWordWorkerService<in T>
{
	IWordWorkerService<T> CreateReport(IEnumerable<T> collection, DateOnly reportDate);

	void SaveReport(string outputPath);
}