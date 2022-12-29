namespace Application.Features.Dishes.Queries;

public record GetDishWithCategoryCommand
{
    public int Id { get; init; }
    public string? CategoryTitle { get; init; }
    public IEnumerable<GetDishCommand>? Dishes { get; init; }
}