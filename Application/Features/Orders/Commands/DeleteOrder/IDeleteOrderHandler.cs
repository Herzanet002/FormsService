using Application.Features.Dishes;
using Application.Interfaces;

namespace Application.Features.Orders.Commands.DeleteOrder;

public interface IDeleteOrderHandler : IHandler
{
    Task<OrderDto?> HandleDeleteOrder(OrderDto order);
}