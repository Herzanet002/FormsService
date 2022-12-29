namespace Application.Features.Dishes.Queries;

public record GetDishCommand
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int DishPrice { get; init; }
    public string? DishCategoryName { get; init; }
    public int DishCategoryId { get; init; }
}

//public record CategoryDto
//{
//    public string? DishCategoryName { get; init; }
//    public int DishCategoryId { get; init; }
//}