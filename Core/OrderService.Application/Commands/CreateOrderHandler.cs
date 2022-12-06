using MediatR;
using OrderService.Application.Dtos;
using OrderService.Application.Mappers;
using OrderService.Domain.Models;
using OrderService.Domain.Repositories;

namespace OrderService.Application.Commands
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, OrderDto>
    {
        private readonly IOrderRepository orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var user = request.Dto.User.FromDto();
            var shippingAddress = request.Dto.ShippingAddress.FromDto();

            var order = Order.Create(user, shippingAddress);
            foreach (var productDto in request.Dto.Products)
            {
                order.AddProduct(productDto.FromDto(), productDto.OrderedQuantity);
            }

            order.CalculateTotalValue();

            await orderRepository.SaveAsync(order, cancellationToken);

            return order.ToDto();
        }
    }
}