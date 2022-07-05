using Common.Domain;
using PhotoManagementApp.Domain.Package.ValueObjects;

namespace PhotoManagementApp.Domain.Package
{
    public class Package : EntityBase<Guid>, IAggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; } 
        public DateTimeOffset DateCreated { get; private set; }
        public Guid UserCreatedId { get; private set; }
        public DateTimeOffset? DateLastModified { get; private set; }
        public Guid? UserLastModifiedId { get; private set; }
        public bool Active { get; private set; }

        public List<PackageRestrictionValue> RestrictionValues { get; private set; } = new();

        private Package() { } 

        public static Package Create(
            string code, 
            string name,
            List<PackageRestrictionValue> restrictionValues)
        {
            return new Package
            {
                Active = true,
                Code = code,
                Name = name, 
                RestrictionValues = restrictionValues
            };


        }
    }
}
