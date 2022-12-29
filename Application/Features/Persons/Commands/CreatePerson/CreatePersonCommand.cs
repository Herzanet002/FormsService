namespace Application.Features.Persons.Commands.CreatePerson
{
    public record CreatePersonCommand
    {
        public int? Id { get; set; }
        public string Name { get; init; }
    }
}
