using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    
    public DateTime? DeliveryDate { get; set; }
    
    public OrderStatus Status { get; set; }

    public List<ProductDTO> Products { get; set; } = new();

    public UserDTO User { get; set; }
    public AddressDTO DeliveryAddress { get; set; }
    
    public OrderDTO(int id, DateTime orderDate, DateTime? deliveryDate, OrderStatus status, List<ProductDTO> products, UserDTO user, AddressDTO deliveryAddress)
    {
        this.Id = id;
        this.OrderDate = orderDate;
        this.DeliveryDate = deliveryDate;
        this.Status = status;
        this.Products = products;
        this.User = user;
        this.DeliveryAddress = deliveryAddress;
    }

    public static OrderDTO FromEntity(Order order)
    {
        return new OrderDTO(
            order.Id,
            order.OrderDate,
            order.DeliveryDate,
            order.Status,
            ProductDTO.FromEntities(order.Products),
            UserDTO.FromEntity(order.User),
            AddressDTO.FromEntity(order.DeliveryAddress)
        );
    }

    public static Order ToEntity(OrderDTO order)
    {
        return new Order()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            Products = ProductDTO.ToEntities(order.Products),
            User = UserDTO.ToEntity(order.User),
            DeliveryAddress = AddressDTO.ToEntity(order.DeliveryAddress)
        };
    }
    
}


