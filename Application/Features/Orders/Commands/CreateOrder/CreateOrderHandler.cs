using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICreateOrderHandler
{
    private readonly IOrderRepository _ordersRepository;

    public CreateOrderHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<OrderDto?> HandleCreateOrder(OrderDto orderDto)
    {
        var order = orderDto.Adapt<Order>();
        var created = await _ordersRepository.Add(order);
        return created.Adapt<OrderDto>();
    }
}