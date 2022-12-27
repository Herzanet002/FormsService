using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Orders.Queries.GetOrders;

public interface IGetAllOrdersHandler : IHandler
{
    Task<IEnumerable<Order>> HandleGetAllOrders();
}