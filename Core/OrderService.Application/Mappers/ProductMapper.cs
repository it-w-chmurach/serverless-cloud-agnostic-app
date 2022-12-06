using OrderService.Application.Dtos;
using OrderService.Domain.Models;

namespace OrderService.Application.Mappers
{
    internal static class ProductMapper
    {
        public static Product FromDto(this ProductDto product)
        {
            return Product.Create(
                id: ProductId.FromValue(product.Id),
                name: product.Name,
                price: product.Price);
        }
    }
}