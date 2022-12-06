using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class OrderStatusHistory : ValueObject
    {
        public OrderStatusHistory(OrderStatus status)
        {
            Status = status;
            Timestamp = DateTime.UtcNow;
        }

        public OrderStatus Status { get; }
        public DateTime Timestamp { get; }

        public static OrderStatusHistory Create(OrderStatus status)
            => new(status);
    }
}