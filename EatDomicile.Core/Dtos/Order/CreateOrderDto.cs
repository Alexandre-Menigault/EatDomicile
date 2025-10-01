using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Dtos.Product;
using EatDomicile.Core.Dtos.User;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Dtos.Order;

public class CreateOrderDto
{
    public List<int> ProductIds { get; set; } = new();

    public int UserId { get; set; }
    public int DeliveryAddressId { get; set; }
}