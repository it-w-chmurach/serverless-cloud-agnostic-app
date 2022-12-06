using MediatR;
using OrderService.Application.Dtos;

namespace OrderService.Application.Commands
{
    public class CreateOrder : IRequest<OrderDto>
    {
        public CreateOrder(NewOrderDto dto)
        {
            Dto = dto;
        }

        public NewOrderDto Dto { get; }
    }
}