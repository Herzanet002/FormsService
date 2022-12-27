using Application.Features.Dishes;
using Domain.Interfaces.Repositories;
using Mapster;

namespace Application.Features.Orders.Queries.GetOrders
{
    internal class GetOrderByIdHandler : IGetOrderByIdHandler
    {
        private readonly IOrderRepository _ordersRepository;

        public GetOrderByIdHandler(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<OrderDto?> HandleGetOrderById(int id)
        {
            var order = await _ordersRepository.FindById(id);
            return order?.Adapt<OrderDto>();
        }
    }
}
