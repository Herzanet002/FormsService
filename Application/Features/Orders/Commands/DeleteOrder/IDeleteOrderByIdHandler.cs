using Application.Interfaces;

namespace Application.Features.Orders.Commands.DeleteOrder;

public interface IDeleteOrderByIdHandler : IHandler
{
    Task<OrderDto?> HandleDeleteOrderById(int id);
}