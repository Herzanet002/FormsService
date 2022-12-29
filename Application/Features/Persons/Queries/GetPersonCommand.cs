namespace Application.Features.Persons.Queries;

public record GetPersonCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
}