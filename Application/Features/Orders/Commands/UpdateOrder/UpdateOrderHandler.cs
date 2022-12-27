using Application.Features.Dishes;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Commands.UpdateOrder;

internal class UpdateOrderHandler : IUpdateOrderHandler
{
    private readonly IOrderRepository _ordersRepository;

    public UpdateOrderHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public async Task<OrderDto> HandleUpdateOrder(OrderDto orderDto)
    {
        var order = orderDto.Adapt<Order>();
        var updated = await _ordersRepository.Update(order);
        return updated.Adapt<OrderDto>();
    }
}