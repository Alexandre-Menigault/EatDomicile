using System.Text;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    
    public DateTime? DeliveryDate { get; set; }
    
    public OrderStatus Status { get; set; }

    public List<ProductDTO>? Products { get; set; }
    public List<int> ProductIds { get; set; } = new();

    // public UserDTO? User { get; set; }
    public int UserId { get; set; }
    //public AddressDTO? DeliveryAddress { get; set; }
    public int DeliveryAddressId { get; set; }
    
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

    public static OrderDTO FromEntity(Order order)
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

    public static Order ToEntity(OrderDTO order)
    {
        return new Order()
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

public static class OrderExtentions
{
    public static String AsString(this OrderDTO order)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Order> {order.Id}");
        sb.AppendLine($"\tUserId = {order.UserId}");
        // sb.AppendLine($"\tUser = {order.User!.FirstName} {order.User.LastName}");
        sb.AppendLine($"\tAddressId = {order.DeliveryAddressId}");
        sb.AppendLine($"\tProducts = {string.Join(", ", order.Products!.Select(p => p.Name))}");
        sb.AppendLine($"\tStatus = {order.Status}");
        sb.AppendLine($"\tDeliveryDate = {order.DeliveryDate}");
        sb.AppendLine($"\tOrderDate = {order.OrderDate}");
        sb.Append("");
        return sb.ToString();
    }
    public static String AsString(this List<OrderDTO> orders)
    {
        var sb = new StringBuilder();
        foreach (var order in orders)
        {
            sb.AppendLine(order.AsString());
        }

        return sb.ToString();

    }
}


