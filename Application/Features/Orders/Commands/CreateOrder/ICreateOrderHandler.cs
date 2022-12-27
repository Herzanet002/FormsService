using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Commands.CreateOrder;

public interface ICreateOrderHandler : IHandler
{
    Task<Order?> HandleCreateOrder(Order order);
}