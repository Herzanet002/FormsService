using Application.Features.Dishes;
using Application.Interfaces;

namespace Application.Features.Orders.Commands.UpdateOrder;

public interface IUpdateOrderHandler : IHandler
{
    Task<OrderDto> HandleUpdateOrder(OrderDto orderDto);
}