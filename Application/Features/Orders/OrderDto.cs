using Domain.Entities;

namespace Application.Features.Orders;

public record OrderDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Location Location { get; set; }
    public DateTimeOffset DateForming { get; set; }
}