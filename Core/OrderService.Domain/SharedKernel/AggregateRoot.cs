namespace OrderService.Domain.SharedKernel
{
    public abstract class AggregateRoot<TKey> : IEntity<TKey> where TKey : ValueObject
    {
        public TKey Id { get; protected set; }
    }
}