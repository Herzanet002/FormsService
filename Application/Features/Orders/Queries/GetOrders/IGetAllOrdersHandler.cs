using Application.Interfaces;

namespace Application.Features.Orders.Queries.GetOrders;

public interface IGetAllOrdersHandler : IHandler
{
    Task<IEnumerable<OrderDto>> HandleGetAllOrders();
}