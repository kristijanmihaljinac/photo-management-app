using Common.Mediator.Events;

namespace Common.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid Id { get; }

        DateTimeOffset OccurredOn { get; }
    }
}
