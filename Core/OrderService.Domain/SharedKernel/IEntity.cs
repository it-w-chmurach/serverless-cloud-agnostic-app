namespace OrderService.Domain.SharedKernel
{
    public interface IEntity<TKey> where TKey : ValueObject
    {
        TKey Id { get; }
    }
}