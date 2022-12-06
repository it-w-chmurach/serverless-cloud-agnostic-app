using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class OrderItem : ValueObject
    {
        private OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Quantity { get; }

        internal static OrderItem Create(Product product, int quantity)
            => new(product, quantity);
    }
}