namespace Application.Features.Categories.Queries
{
    public record GetCategoryCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
