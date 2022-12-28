using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler : IDeleteOrderHandler
{
    private readonly IOrderRepository _ordersRepository;

    public DeleteOrderHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<OrderDto?> HandleDeleteOrder(OrderDto orderDto)
    {
        var order = orderDto.Adapt<Order>();
        var removed = await _ordersRepository.Remove(order);
        return removed?.Adapt<OrderDto>();
    }
}