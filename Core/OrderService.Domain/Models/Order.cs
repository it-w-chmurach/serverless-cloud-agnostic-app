using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class Order : AggregateRoot<OrderId>
    {
        private readonly List<OrderItem> _orderItems;
        private readonly List<OrderStatusHistory> _statusHistory;

        private Order(User user, Address shippingAddress)
        {
            Id = OrderId.New();
            User = user;
            ShippingAddress = shippingAddress;
            CreatedOn = DateTime.UtcNow;
            Status = OrderStatus.New;

            _orderItems = new List<OrderItem>();

            _statusHistory = new List<OrderStatusHistory>
            {
                OrderStatusHistory.Create(Status)
            };

        }

        public User User { get; }
        public Address ShippingAddress { get; }
        public DateTime CreatedOn { get; }
        public OrderStatus Status { get; private set; }
        public decimal TotalValue { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _orderItems;
        public IReadOnlyCollection<OrderStatusHistory> StatusHistory => _statusHistory;

        public static Order Create(User user, Address shippingAddress)
            => new(user, shippingAddress);

        public void AddProduct(Product product, int quantity)
        {
            var orderItem = OrderItem.Create(product, quantity);
            _orderItems.Add(orderItem);
        }

        public void CalculateTotalValue()
        {
            TotalValue = _orderItems.Sum(x => x.Product.Price * x.Quantity);

            if (User.IsVip())
                ApplyVipDiscount();
        }

        public void Complete()
        {
            if (Status != OrderStatus.New)
                throw new OrderException("Only new orders can be completed.");

            Status = OrderStatus.Completed;

            _statusHistory.Add(OrderStatusHistory.Create(Status));
        }

        public void Cancel()
        {
            if (Status != OrderStatus.New)
                throw new OrderException("Only new orders can be cancelled.");

            Status = OrderStatus.Cancelled;

            _statusHistory.Add(OrderStatusHistory.Create(Status));
        }

        private void ApplyVipDiscount()
        {
            int percentage = 10;
            decimal discountValue = Math.Round(TotalValue * percentage / 100m, 2);
            TotalValue -= discountValue;
        }
    }
}