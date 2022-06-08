using Common.Domain;

namespace PhotoManagementApp.Domain.Package
{
    public class Package : EntityBase<long>, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; } 
        public DateTimeOffset DateCreated { get; private set; }
        public Guid UserCreatedId { get; private set; }
        public DateTimeOffset? DateLastModified { get; private set; }
        public Guid? UserLastModifiedId { get; private set; }
        public bool Active { get; private set; }

        private Package()
        {

        }
    }
}
