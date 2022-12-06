using OrderService.Domain.Models;

namespace OrderService.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> FindAsync(Guid id, CancellationToken token = default);
        Task<Order> SaveAsync(Order order, CancellationToken token = default);
    }
}