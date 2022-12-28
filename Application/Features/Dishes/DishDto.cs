namespace Application.Features.Dishes;

public record DishDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? DishCategoryName { get; init; }
    public int DishPrice { get; init; }
    public int DishCategoryId { get; init; }

}