using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICreateOrderHandler
{
    private readonly IOrderRepository _ordersRepository;

    public CreateOrderHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<Order?> HandleCreateOrder(Order order)
    {
        return await _ordersRepository.Add(order);
    }
}