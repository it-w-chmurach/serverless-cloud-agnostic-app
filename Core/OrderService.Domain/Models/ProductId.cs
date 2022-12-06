using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class ProductId : ValueObject
    {
        private ProductId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static ProductId FromValue(Guid value)
            => new(value);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}