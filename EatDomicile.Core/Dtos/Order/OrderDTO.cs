using System.Text;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Dtos.Product;
using EatDomicile.Core.Dtos.User;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Dtos.Order;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    
    public DateTime? DeliveryDate { get; set; }
    
    public OrderStatus Status { get; set; }

    public List<ProductDTO>? Products { get; set; }
    public List<int> ProductIds { get; set; } = new();

    public int UserId { get; set; }
    public UserDTO? User { get; set; }
    public int DeliveryAddressId { get; set; }
    public AddressDTO? DeliveryAddress { get; set; }

    public OrderDTO()
    {
        
    }
    
    public OrderDTO(int id, DateTime orderDate, DateTime? deliveryDate, OrderStatus status, List<ProductDTO>? products, int userId, int deliveryAddressId)
    {
        this.Id = id;
        this.OrderDate = orderDate;
        this.DeliveryDate = deliveryDate;
        this.Status = status;
        this.Products = products;
        this.UserId = userId;
        this.DeliveryAddressId = deliveryAddressId;
    }

    public static OrderDTO FromEntity(Models.Order order)
    {
        return new OrderDTO(
            order.Id,
            order.OrderDate,
            order.DeliveryDate,
            order.Status,
            order.Products == null ? null :ProductDTO.FromEntities(order.Products),
            order.UserId, //== null ? null : UserDTO.FromEntity(order.User),
            order.DeliveryAddressId
        )
        {
            ProductIds = order.Products?.Select(p => p.Id).ToList() ?? new List<int>()
        };
    }

    public static Models.Order ToEntity(OrderDTO order)
    {
        return new Models.Order()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            Products = null, //= order.Products == null ? null :ProductDTO.ToEntities(order.Products),
            UserId = order.UserId, // = order.User == null ? null : UserDTO.ToEntity(order.User),
            DeliveryAddressId = order.DeliveryAddressId
        };
    }
    
}
