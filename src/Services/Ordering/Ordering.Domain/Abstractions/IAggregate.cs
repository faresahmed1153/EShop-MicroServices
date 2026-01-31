namespace Ordering.Domain.Abstractions;

public interface IAggregate : IEntity
{
}

public interface IAggregate<T> : IAggregate, IEntity<T>
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    IDomainEvent[] ClearDomainEvents();
}