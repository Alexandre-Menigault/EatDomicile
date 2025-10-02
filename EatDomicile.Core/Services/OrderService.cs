using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Services;

public class OrderService
{
    private readonly ProductContext _context;


    public OrderService(ProductContext context)
    {
        _context = context;
    }

    public OrderDTO CreateOrder(OrderDTO orderDTO)
    {
        if(orderDTO.Products?.Count == 0)
            throw new ArgumentException("Order must contain at least one product.");
        var productIds = (orderDTO.ProductIds?.Count > 0
                    ? orderDTO.ProductIds
                    : orderDTO.Products?.Select(p => p.Id).ToList()
            )!
            .Where(id => id > 0)
            .Distinct()
            .ToList();

        var products = productIds.Select(id => new Product() { Id = id, Name = null!, Price = 0}).ToList();
        foreach (var p in products)
        {
            _context.Attach(p);
        }

        var order = new Order
        {
            OrderDate = orderDTO.OrderDate,
            DeliveryDate = orderDTO.DeliveryDate,
            Status = orderDTO.Status,
            UserId = orderDTO.UserId,
            DeliveryAddressId = orderDTO.DeliveryAddressId,
            Products = products
        };

        _context.Orders.Add(order);
        _context.SaveChanges();
        Console.WriteLine($"Order created with {order.Id}");
        return OrderDTO.FromEntity(order);
    }

    public List<OrderDTO> GetAllOrders()
    {
        return _context.Orders
            //.Include(o => o.User)
            .Include(o => o.Products)
            //.Include(o => o.DeliveryAddress)
            .Select(OrderDTO.FromEntity).ToList();
    }
    
    public OrderDTO? GetOrderById(int id)
    {
        var order = _context.Orders
            .Where(o => o.Id == id)
            //.Include(o => o.User)
            .Include(o => o.Products)
            //.Include(o => o.DeliveryAddress)
            .FirstOrDefault();
                
        return order is null ? null : OrderDTO.FromEntity(order);
    }

    public OrderDTO UpdateOrderEnCuisine(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.EnCuisine;
            _context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }

    public OrderDTO UpdateOrderEnLivraison(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.EnLivraison;
            _context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }
    
    public OrderDTO UpdateOrderLivree(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order is not null)
        {
            order.Status = OrderStatus.Livree;
            order.DeliveryDate = DateTime.Now;
            _context.SaveChanges();
        }
        return OrderDTO.FromEntity(order);
    }

    public void DeleteOrder(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order is not null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }

    public List<OrderDTO> GetOrdersEnCours()
    {
        return _context.Orders
            .Where(o => o.Status != OrderStatus.Livree)
            //.Include(o => o.User)
            .Include(o => o.Products)
            //.Include(o => o.DeliveryAddress)
            .Select(OrderDTO.FromEntity).ToList();
    }
    
    public List<int> GetUsersWithOrders()
    {
        return _context.Orders
            // .Include(o => o.User)
            // .Include(o => o.User.Address)
            .Select(o => o.UserId)
            .Distinct()
            .ToList();
    }
    
    public List<OrderDTO> GetVegetarianOrders()
    {
        return _context.Orders
            // .Include(o => o.User)
            //.Include(o => o.DeliveryAddress)
            .Include(o => o.Products)
            .Where(o => o.Products!.OfType<Food>().All(f => f.Vegetarien))
            .Select(OrderDTO.FromEntity)
            .ToList();
    }
    
    
}
