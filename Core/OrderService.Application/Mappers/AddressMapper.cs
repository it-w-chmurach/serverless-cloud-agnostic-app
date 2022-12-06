using OrderService.Application.Dtos;
using OrderService.Domain.Models;

namespace OrderService.Application.Mappers
{
    internal static class AddressMapper
    {
        public static Address FromDto(this AddressDto dto)
        {
            return Address.Create(
                country: dto.Country,
                city: dto.City,
                postalCode: dto.PostalCode,
                addressLine: dto.AddressLine);
        }
    }
}