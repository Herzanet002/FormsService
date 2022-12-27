using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Commands.UpdateOrder;

public interface IUpdateOrderHandler : IHandler
{
    Task<Order> HandleUpdateOrder(Order order);
}