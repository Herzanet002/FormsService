using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IDeleteOrderHandler
    {
        private readonly IOrderRepository _ordersRepository;

        public DeleteOrderHandler(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public Task<Order?> HandleDeleteOrder(Order order)
        {
            return _ordersRepository.Remove(order);
        }
    }
}
