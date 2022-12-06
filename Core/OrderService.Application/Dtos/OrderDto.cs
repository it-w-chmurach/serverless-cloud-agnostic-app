namespace OrderService.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public OrderStatusDto Status { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}