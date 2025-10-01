using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Exceptions;

public class OrderStatusException : Exception
{
    private OrderStatus[] _orderStatus;
    public OrderStatusException(OrderStatus[] expectedStatuses)
    {
        this._orderStatus = expectedStatuses;
    }
    
    public override string Message
    {
        get 
        {
            if(!_orderStatus.Any()) return "No Order Status expected";
            var orderStatus = string.Join(", ", _orderStatus);
            return $"Order status must be one of {orderStatus}";
        }
    }
}