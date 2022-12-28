namespace Application.Features.Dishes;

public record DishWithCategoryDto
{
    public int Id { get; init; }
    public string? CategoryTitle { get; init; }

    public IEnumerable<DishDto>? Dishes { get; init; }
}