using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Commands.DeleteOrder;

internal class DeleteOrderByIdHandler : IDeleteOrderByIdHandler
{
    private readonly IOrderRepository _ordersRepository;

    public DeleteOrderByIdHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<OrderDto?> HandleDeleteOrderById(int id)
    {
        var removed = await _ordersRepository.RemoveById(id);
        return removed?.Adapt<OrderDto>();
    }
}