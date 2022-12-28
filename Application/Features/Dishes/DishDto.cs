namespace Application.Features.Dishes;

public record DishDto
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int DishPrice { get; set; }

    public int DishCategoryId { get; set; }
}