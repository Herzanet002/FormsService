using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Queries.GetOrders;

public class GetAllOrdersHandler : IGetAllOrdersHandler
{
    private readonly IOrderRepository _ordersRepository;

    public GetAllOrdersHandler(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<IEnumerable<OrderDto>> HandleGetAllOrders()
    {
        var orders = await _ordersRepository.GetAllWithInclude(x => x.Person);
        return orders.Adapt<IEnumerable<OrderDto>>();
    }
}