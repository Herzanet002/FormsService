using Application.Features.Orders;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers;

[ApiController]
[Route("/api/[controller]/")]
public class OrdersController : Controller
{
    private readonly ICreateOrderHandler _createOrderHandler;
    private readonly IUpdateOrderHandler _updateOrderHandler;
    private readonly IDeleteOrderHandler _deleteOrderHandler;
    private readonly IGetAllOrdersHandler _getAllOrdersHandler;
    private readonly IGetOrderByIdHandler _getOrderByIdHandler;
    private readonly IDeleteOrderByIdHandler _deleteOrderByIdHandler;

    public OrdersController(ICreateOrderHandler createOrderHandler,
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDto order)
    {
        return Ok(await _createOrderHandler.HandleCreateOrder(order));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _getAllOrdersHandler.HandleGetAllOrders());
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        return await _getOrderByIdHandler.HandleGetOrderById(id) is { } item ? Ok(item) : NotFound();
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
    {
        if (id != orderDto.Id) return BadRequest();
        return Ok(await _updateOrderHandler.HandleUpdateOrder(orderDto));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOrder([FromBody] OrderDto order)
    {
        return Ok(await _deleteOrderHandler.HandleDeleteOrder(order));
    }

    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrderById(int id)
    {
        return Ok(await _deleteOrderByIdHandler.HandleDeleteOrderById(id));
    }

}