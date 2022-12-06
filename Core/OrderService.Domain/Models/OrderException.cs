namespace OrderService.Domain.Models
{
    public class OrderException : Exception
    {
        public OrderException(string? message) : base(message)
        {
        }
    }
}