using MediatR;
using OrderService.Application.Dtos;
using OrderService.Domain.Models;

namespace OrderService.Application.Queries
{
    public class FindUserOrdersHandler : IRequestHandler<FindUserOrders, IEnumerable<OrderListDto>>
    {
        public Task<IEnumerable<OrderListDto>> Handle(FindUserOrders request, CancellationToken cancellationToken)
        {
            IEnumerable<OrderListDto>? ordersList = new List<OrderListDto>
            {
                new OrderListDto
                {
                    Id = Guid.Parse("b000b310-df5b-45c7-9562-6f029b71e1a1"),
                    CreateOnUtc = DateTime.Parse("2021-09-23 14:56:32"),
                    Status = new OrderStatusDto
                    {
                        Value = (int)OrderStatus.Completed,
                        Name = OrderStatus.Completed.ToString()
                    }
                },
                new OrderListDto
                {
                    Id = Guid.Parse("e4286207-a6ba-4e0c-8ef8-5252dbed4e08"),
                    CreateOnUtc = DateTime.Parse("2022-01-15 21:18:54"),
                    Status = new OrderStatusDto
                    {
                        Value = (int)OrderStatus.Cancelled,
                        Name = OrderStatus.Cancelled.ToString()
                    }
                },
                new OrderListDto
                {
                    Id = Guid.Parse("eb6487cb-5c12-43d3-a50c-8bfd2b1df343"),
                    CreateOnUtc = DateTime.Parse("2022-03-08 09:51:12"),
                    Status = new OrderStatusDto
                    {
                        Value = (int)OrderStatus.Completed,
                        Name = OrderStatus.Completed.ToString()
                    }
                }
            };

            return Task.FromResult(ordersList);
        }
    }
}