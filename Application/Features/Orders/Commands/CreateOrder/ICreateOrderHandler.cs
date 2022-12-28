using Application.Interfaces;

namespace Application.Features.Orders.Commands.CreateOrder;

public interface ICreateOrderHandler : IHandler
{
    Task<OrderDto?> HandleCreateOrder(OrderDto order);
}