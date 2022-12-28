namespace Application.Features.Persons;

public record PersonDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}