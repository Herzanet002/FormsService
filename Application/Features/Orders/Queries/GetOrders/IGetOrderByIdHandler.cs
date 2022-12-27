using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Queries.GetOrders;

public interface IGetOrderByIdHandler : IHandler
{
    Task<Order?> HandleGetOrderById(int id);
}