using Application.Features.Dishes.Queries.GetDishes;
using Application.Features.Orders;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetOrders;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

[ApiController]
[Route("/api/[controller]/")]
public class OrderController : Controller
{
    private readonly ICreateOrderHandler _createOrderHandler;
    private readonly IUpdateOrderHandler _updateOrderHandler;
    private readonly IDeleteOrderHandler _deleteOrderHandler;
    private readonly IGetAllOrdersHandler _getAllOrdersHandler;
    private readonly IGetOrderByIdHandler _getOrderByIdHandler;
    private readonly IDeleteOrderByIdHandler _deleteOrderByIdHandler;

    public OrderController(ICreateOrderHandler createOrderHandler, 
        IUpdateOrderHandler updateOrderHandler, 
        IDeleteOrderHandler deleteOrderHandler,
        IGetAllOrdersHandler getAllOrdersHandler,
        IGetOrderByIdHandler getOrderByIdHandler,
        IDeleteOrderByIdHandler deleteOrderByIdHandler)
    {
        _createOrderHandler = createOrderHandler;
        _updateOrderHandler = updateOrderHandler;
        _deleteOrderHandler = deleteOrderHandler;
        _getAllOrdersHandler = getAllOrdersHandler;
        _getOrderByIdHandler = getOrderByIdHandler;
        _deleteOrderByIdHandler = deleteOrderByIdHandler;
    }
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDto order)
    {
        return Ok(await _createOrderHandler.HandleCreateOrder(order));
    }

    [HttpGet]
    [Route("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _getAllOrdersHandler.HandleGetAllOrders());
    }

    [HttpGet]
    [Route("getById/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        return await _getOrderByIdHandler.HandleGetOrderById(id) is { } item ? Ok(item) : NotFound();
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrder([FromBody] OrderDto order)
    {
        return Ok(await _updateOrderHandler.HandleUpdateOrder(order));
    }

    [HttpDelete]
    [Route("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOrder([FromBody] OrderDto order)
    {
        return Ok(await _deleteOrderHandler.HandleDeleteOrder(order));
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOrderById(int id)
    {
        return Ok(await _deleteOrderByIdHandler.HandleDeleteOrderById(id));
    }

}