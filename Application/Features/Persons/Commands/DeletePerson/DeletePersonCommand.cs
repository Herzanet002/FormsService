namespace Application.Features.Persons.Commands.DeletePerson
{
    public record DeletePersonCommand
    {
        public int Id { get; init; }
        public string? Name { get; init; }
    }
}
