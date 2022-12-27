using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Commands.DeleteOrder;

public interface IDeleteOrderHandler : IHandler
{
    Task<Order?> HandleDeleteOrder(Order order);
}