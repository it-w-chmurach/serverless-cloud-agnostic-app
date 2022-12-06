using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class UserId : ValueObject
    {
        private UserId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static UserId FromValue(Guid value)
            => new(value);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}