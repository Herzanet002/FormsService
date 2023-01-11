namespace Application.Features.Dishes.Commands.CreateDish;

public record CreateDishCommand
{
    public int? Id { get; init; }
    public string Name { get; init; }
    public int DishPrice { get; init; }
    public int DishCategoryId { get; init; }
}