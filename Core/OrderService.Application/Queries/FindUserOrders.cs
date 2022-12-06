using MediatR;
using OrderService.Application.Dtos;

namespace OrderService.Application.Queries
{
    public class FindUserOrders : IRequest<IEnumerable<OrderListDto>>
    {
        public FindUserOrders(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}