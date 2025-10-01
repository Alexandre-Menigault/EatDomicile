using System.Text;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Dtos.Product;
using EatDomicile.Core.Dtos.User;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Dtos.Order;

public static class OrderExtentions
{

    public static OrderDTO ToDto(this Models.Order order)
    {
        return new OrderDTO()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            Products = order.Products?.Select(p => p.ToDto()).ToList(),
            ProductIds = order.Products?.Select(p => p.Id).ToList() ?? [],
            UserId = order.UserId,
            User = order.User?.ToDto(),
            DeliveryAddressId = order.DeliveryAddressId,
            DeliveryAddress = order.DeliveryAddress?.ToDto()
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <returns>Returns an Order model WITHOUT the Products being put in as its is only ids</returns>
    public static Models.Order ToEntity(this CreateOrderDto order)
    {
        return new Models.Order()
        {
            DeliveryDate = null,
            Status = OrderStatus.Validee,
            DeliveryAddressId = order.DeliveryAddressId,
            UserId = order.UserId,
            OrderDate = DateTime.Now,
        };
    }
    
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