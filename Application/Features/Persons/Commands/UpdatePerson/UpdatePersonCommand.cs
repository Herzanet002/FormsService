namespace Application.Features.Persons.Commands.UpdatePerson
{
    public record UpdatePersonCommand
    {
        public string Name { get; init; }
    }
}
