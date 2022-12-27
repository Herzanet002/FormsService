using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Orders.Queries.GetOrders
{
    internal class GetOrderByIdHandler : IGetOrderByIdHandler
    {
        private readonly IOrderRepository _ordersRepository;

        public GetOrderByIdHandler(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<Order?> HandleGetOrderById(int id)
        {
            return await _ordersRepository.FindById(id);
        }
    }
}
