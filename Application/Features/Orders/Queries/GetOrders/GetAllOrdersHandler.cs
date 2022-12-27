using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;

namespace Application.Features.Orders.Queries.GetOrders
{
    public class GetAllOrdersHandler : IGetAllOrdersHandler
    {
        private readonly IOrderRepository _ordersRepository;

        public GetAllOrdersHandler(IOrderRepository ordersRepository)
        {   
            _ordersRepository = ordersRepository;
        }
        public async Task<IEnumerable<Order>> HandleGetAllOrders()
        {
            return await _ordersRepository.GetAll();
        }
    }
}
