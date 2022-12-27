using Application.Features.Dishes;
using Application.Interfaces;

namespace Application.Features.Orders.Queries.GetOrders;

public interface IGetOrderByIdHandler : IHandler
{
    Task<OrderDto?> HandleGetOrderById(int id);
}