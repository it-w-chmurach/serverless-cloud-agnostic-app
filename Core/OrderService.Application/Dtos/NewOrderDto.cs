namespace OrderService.Application.Dtos
{
    public class NewOrderDto
    {
        public NewOrderDto()
        {
            Products = new List<ProductDto>();
        }

        public UserDto User { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}