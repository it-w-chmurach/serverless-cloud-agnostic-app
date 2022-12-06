using OrderService.Application.Dtos;
using OrderService.Domain.Models;

namespace OrderService.Application.Mappers
{
    internal static class UserMapper
    {
        public static User FromDto(this UserDto dto)
        {
            return User.Create(
                id: UserId.FromValue(dto.Id),
                status: (UserStatus)dto.StatusNumber);
        }
    }
}