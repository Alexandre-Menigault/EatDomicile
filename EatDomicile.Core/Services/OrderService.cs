using Bogus.Extensions;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Services;

public class OrderService
{
    public OrderService()
    {
    }

    public OrderDTO CreateOrder(Order order)
    {
        using var context = new ProductContext();
        context.Orders.Add(order);
        context.SaveChanges();
        Console.WriteLine($"Order created with {order.Id}");
        return OrderDTO.FromEntity(order);
    }

    public List<OrderDTO> GetAllOrders()
    {
        using var context = new ProductContext();
        return context.Orders
            .Include(o => o.User)
            .Include(o => o.Products)
            .Include(o => o.DeliveryAddress)
            .Select(OrderDTO.FromEntity).ToList();
    }
    
    public OrderDTO? GetOrderById(int id)
    {
        using var context = new ProductContext();
        var order = context.Orders
            .Where(o => o.Id == id)
            .Include(o => o.User)
            .Include(o => o.Products)
            .Include(o => o.DeliveryAddress)
            .FirstOrDefault();
                
        return order is null ? null : OrderDTO.FromEntity(order);
    }

    public OrderDTO UpdateOrderEnCuisine(int orderId)
    {
        using var context = new ProductContext();
        var order = context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.EnCuisine;
            context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }

    public OrderDTO UpdateOrderEnLivraison(int orderId)
    {
        using var context = new ProductContext();
        var order = context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.EnLivraison;
            context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }
    
    public OrderDTO UpdateOrderLivree(int orderId)
    {
        using var context = new ProductContext();
        var order = context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.Livree;
            order.DeliveryDate = DateTime.Now;
            context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }

    public void DeleteOrder(int orderId)
    {
        using var context = new ProductContext();
        var order = context.Orders.Find(orderId);
        if (order is not null)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }

    public List<OrderDTO> GetOrdersEnCours()
    {
        using var context = new ProductContext();
        return context.Orders
            .Where(o => o.Status != OrderStatus.Livree)
            .Include(o => o.User)
            .Include(o => o.Products)
            .Include(o => o.DeliveryAddress)
            .Select(OrderDTO.FromEntity).ToList();
    }
    
    public List<UserDTO> GetUsersWithOrders()
    {
        using var context = new ProductContext();
        return context.Orders
            .Include(o => o.User)
            .Include(o => o.User.Address)
            .Select(o => o.User)
            .Distinct()
            .Select(UserDTO.FromEntity)
            .ToList();
    }
    
}
