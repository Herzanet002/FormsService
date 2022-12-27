using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderByIdHandler : IDeleteOrderByIdHandler
    {
        private readonly IOrderRepository _ordersRepository;

        public DeleteOrderByIdHandler(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Order?> HandleDeleteOrderById(int id)
        {
            return await _ordersRepository.RemoveById(id);
        }
    }
}
