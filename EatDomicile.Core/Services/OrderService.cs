using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Order;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Services;

public class OrderService : IOrderService
{
    private readonly ProductContext _context;


    public OrderService(ProductContext context)
    {
        _context = context;
    }

    public async Task<OrderDTO> CreateOrder(CreateOrderDto orderDto)
    {
        if (!orderDto.ProductIds.Any())
        {
            throw new EntityCollectionPropertyIsEmptyException<CreateOrderDto>(nameof(orderDto.ProductIds));
        }
        
        var order = orderDto.ToEntity();
        var products = await _context.Products.Where(p => orderDto.ProductIds.Contains(p.Id)).ToListAsync();
        if (products.Count != orderDto.ProductIds.Count())
        {
            throw new EntityNotFoundException<Product>(orderDto.ProductIds.Except(products.Select(p => p.Id)).First());
        }
        
        var userExists = await _context.Users.AnyAsync(u => u.Id == orderDto.UserId);
        var addressExists = await _context.Addresses.AnyAsync(a => a.Id == orderDto.DeliveryAddressId);

        if (!userExists)
        {
            throw new EntityNotFoundException<User>(orderDto.UserId);
        }

        if (!addressExists)
        {
            throw new EntityNotFoundException<Address>(orderDto.DeliveryAddressId);
        }
        
        order.Products = products;
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order.ToDto();
    }

    public async Task<List<OrderDTO>> GetAllOrders()
    {
        return await 
            this.QueryOrders()
                .Select(o => o.ToDto())
                .ToListAsync();
    }
    
    public Task<OrderDTO> GetOrderById(int id)
    {
        var order = 
            this.QueryOrders()
                .Select(o => o.ToDto())
                .AsEnumerable()
                .FirstOrDefault(o => o.Id == id);

        if (order is null)
        {
            throw new EntityNotFoundException<Order>(id);
        }

        return Task.FromResult(order);
    }

    public async Task UpdateOrderAddress(int orderId, int addressId)
    {
        var  order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        if(order is null) throw new EntityNotFoundException<Order>(orderId);

        // Prevent to change address if order is not validee or en cours
        if (order.Status != OrderStatus.Validee && order.Status != OrderStatus.EnCuisine)
        {
            throw new OrderStatusException([OrderStatus.EnAttenteLivreur, OrderStatus.EnLivraison, OrderStatus.Livree]);
        }
         
        var addressExists = await _context.Addresses.AnyAsync(a => a.Id == addressId);
        if (!addressExists)
        {
            throw new EntityNotFoundException<Address>(addressId);
        }
        
        order.DeliveryAddressId = addressId;
        await _context.SaveChangesAsync();
        
    }


    public async Task UpdateOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        if(order is null) throw new EntityNotFoundException<Order>(orderId);

        OrderStatus newStatus;

        switch (status)
        {
            case OrderStatus.Validee:
                throw new OrderStatusException([]);
                break;
            case OrderStatus.EnCuisine:
                if (order.Status != OrderStatus.Validee)
                {
                    throw new OrderStatusException([OrderStatus.Validee]);   
                }
                newStatus = OrderStatus.EnCuisine;
                break;
            case OrderStatus.EnAttenteLivreur:
                if (order.Status != OrderStatus.EnCuisine)
                {
                    throw new OrderStatusException([OrderStatus.EnCuisine]);
                }
                newStatus = OrderStatus.EnAttenteLivreur;
                break;
            case OrderStatus.EnLivraison:
                if (order.Status != OrderStatus.EnAttenteLivreur)
                {
                    throw new OrderStatusException([OrderStatus.EnAttenteLivreur]);
                }
                newStatus = OrderStatus.EnLivraison;
                break;
            case OrderStatus.Livree:
                if (order.Status != OrderStatus.EnLivraison)
                {
                    throw new OrderStatusException([OrderStatus.EnLivraison]);
                }
                newStatus = OrderStatus.Livree;
                order.DeliveryDate = DateTime.Now;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }

        order.Status = newStatus;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        
        if(order is null) throw new EntityNotFoundException<Order>(id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderDTO>> GetOrdersEnCours()
    {
        return await 
            this.QueryOrders()
                .Where(o => o.Status != OrderStatus.Livree)
                .Select(o => o.ToDto())
                .ToListAsync();
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

    private IQueryable<Order> QueryOrders()
    {
        return _context.Orders
            .Include(o => o.User)
                .ThenInclude(u => u!.Address)
            .Include(o => o.Products)
            .Include(o => o.DeliveryAddress)
            .AsQueryable();
    }
    
}
