using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Orders.Commands.UpdateOrder;

internal class UpdateOrderHandler : IUpdateOrderHandler
{
    private readonly IOrderRepository _ordersRepository;

    public UpdateOrderHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public Task<Order> HandleUpdateOrder(Order order)
    {
        return _ordersRepository.Update(order);
    }
}