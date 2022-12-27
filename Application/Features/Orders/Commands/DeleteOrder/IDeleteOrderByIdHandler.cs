using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Commands.DeleteOrder;

public interface IDeleteOrderByIdHandler : IHandler
{
    Task<Order?> HandleDeleteOrderById(int id);
}