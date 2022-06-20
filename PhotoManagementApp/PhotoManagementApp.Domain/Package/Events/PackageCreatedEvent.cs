using Common.Domain;

namespace PhotoManagementApp.Domain.Package.Events
{
    internal class PackageCreatedEvent : IDomainEvent
    {
        public Guid Id => Guid.NewGuid();

        public DateTimeOffset OccurredOn => DateTimeOffset.UtcNow;
    }
}
