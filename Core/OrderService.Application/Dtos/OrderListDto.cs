namespace OrderService.Application.Dtos
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public DateTime CreateOnUtc { get; set; }
        public OrderStatusDto Status { get; set; }
    }
}