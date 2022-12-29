namespace Application.Features.Dishes.Commands.DeleteDish
{
    public record DeleteDishCommand
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public int? DishCategoryId { get; init; }
    }
}
