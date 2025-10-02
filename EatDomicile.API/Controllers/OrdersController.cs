using EatDomicile.Core.Dtos.Order;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrderService _orderService;

    public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }
    
    // GET ALL
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDTO>))]
    public async Task<IResult> GetOrders()
    {
        var orders = await _orderService.GetAllOrders();
        return Results.Ok(orders);
    }
    
    // GET MANY

    [HttpGet("status/en_cours")]
    public async Task<IResult> GetOrdersEnCours()
    {
        var orders = await _orderService.GetOrdersEnCours();
        return Results.Ok(orders);
    }
    
    // GET ONE

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> GetOrderById(int id)
    {
        try
        {
            var order = await _orderService.GetOrderById(id);
            return Results.Ok(order);
        }
        catch (EntityNotFoundException<Order> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
    // POST

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> AddOrder([FromBody] CreateOrderDto orderDto)
    {
        try
        {
            var order = await _orderService.CreateOrder(orderDto);
            var location = Url.Action("GetOrderById", new { id = order.Id });
            return Results.Created(location, order);
        }
        catch (EntityCollectionPropertyIsEmptyException<CreateOrderDto> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (EntityNotFoundException<Burger> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (EntityNotFoundException<Address> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (EntityNotFoundException<User> e)
        {
            return Results.BadRequest(e.Message);
        }
    }
    // PUT
    [HttpPatch("{id}/delivery_address/{addressId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> UpdateOrderAddress(int id, int addressId)
    {
        try
        {
            await _orderService.UpdateOrderAddress(id, addressId);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<Order> e)
        {
            return Results.NotFound(e.Message);
        }
        catch (EntityNotFoundException<Address> e)
        {
            return Results.NotFound(e.Message);
        }
        catch (OrderStatusException e)
        {
            return Results.BadRequest(e.Message);
        }
    }

    [HttpPatch("{id}/status/{status}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IResult> UpdateOrderStatus(int id, OrderStatus status)
    {
        try
        {
            await _orderService.UpdateOrderStatus(id, status);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<Order> e)
        {
            return Results.NotFound(e.Message);
        } 
        catch (OrderStatusException e)
        {
            return Results.BadRequest(e.Message);
        }
    }
    
    // DELETE

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> DeleteOrder(int id)
    {
        try
        {
            await _orderService.DeleteOrder(id);
            return Results.NoContent(); 
        } catch (EntityNotFoundException<Order> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
}