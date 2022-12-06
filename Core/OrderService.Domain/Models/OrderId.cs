using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class OrderId : ValueObject
    {
        private OrderId()
        {
            Value = Guid.NewGuid();
        }

        public Guid Value { get; }

        public static OrderId New()
            => new();

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}