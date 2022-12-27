using Domain.Enums;

namespace Application.Features.Dishes
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Location Location { get; set; }
        public DateTimeOffset DateForming { get; set; }
    }
}
