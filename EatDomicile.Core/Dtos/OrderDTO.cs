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

    public UserDTO? User { get; set; }
    public AddressDTO? DeliveryAddress { get; set; }
    
    public OrderDTO(int id, DateTime orderDate, DateTime? deliveryDate, OrderStatus status, List<ProductDTO>? products, UserDTO? user, AddressDTO? deliveryAddress)
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
            order.Products == null ? null :ProductDTO.FromEntities(order.Products),
            order.User == null ? null : UserDTO.FromEntity(order.User),
            order.DeliveryAddress == null ? null : AddressDTO.FromEntity(order.DeliveryAddress)
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
            Products = order.Products == null ? null :ProductDTO.ToEntities(order.Products),
            User = order.User == null ? null : UserDTO.ToEntity(order.User),
            DeliveryAddress = order.DeliveryAddress == null ? null : AddressDTO.ToEntity(order.DeliveryAddress)
        };
    }
    
}

public static class OrderExtentions
{
    public static String AsString(this OrderDTO order)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Order> {order.Id}");
        sb.AppendLine($"\tUser = {order.User!.FirstName} {order.User.LastName}");
        sb.AppendLine($"\tAddress = {order.DeliveryAddress!.AsString()}");
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


