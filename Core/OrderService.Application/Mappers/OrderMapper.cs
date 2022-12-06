using OrderService.Application.Dtos;
using OrderService.Domain.Models;

namespace OrderService.Application.Mappers
{
    internal static class OrderMapper
    {
        public static OrderDto ToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id.Value,
                User = new UserDto
                {
                    Id = order.User.Id.Value,
                    StatusNumber = (int)order.User.Status
                },
                Status = new OrderStatusDto
                {
                    Value = (int)order.Status,
                    Name = order.Status.ToString()
                },
                ShippingAddress = new AddressDto
                {
                    Country = order.ShippingAddress.Country,
                    City = order.ShippingAddress.City,
                    PostalCode = order.ShippingAddress.PostalCode,
                    AddressLine = order.ShippingAddress.AddressLine,
                },
                Products = order.Items.Select(x => new ProductDto
                {
                    Id = x.Product.Id.Value,
                    Name = x.Product.Name,
                    OrderedQuantity = x.Quantity,
                    Price = x.Product.Price
                })
            };
        }
    }
}