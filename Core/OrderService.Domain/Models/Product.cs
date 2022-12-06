using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class Product : IEntity<ProductId>
    {
        private Product(ProductId id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public ProductId Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public static Product Create(ProductId id, string name, decimal price)
            => new(id, name, price);
    }
}