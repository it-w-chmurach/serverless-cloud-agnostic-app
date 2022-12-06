using OrderService.Domain.Models;
using OrderService.Domain.Repositories;

namespace OrderService.Persistence.MongoDb.Repositories
{
    public class OrderAggregateRepository : IOrderRepository
    {
        public Task<Order> FindAsync(Guid id, CancellationToken token = default)
        {
            var order = Order.Create(
                User.Create(UserId.FromValue(Guid.NewGuid()), UserStatus.Regular),
                Address.Create("A", "B", "C", "D"));

            return Task.FromResult(order);
        }

        public Task<Order> SaveAsync(Order order, CancellationToken token = default)
        {
            return Task.FromResult(order);
        }
    }
}