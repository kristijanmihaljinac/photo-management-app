using Common.Domain;

namespace PhotoManagementApp.Domain.Package.ValueObjects
{
    public class PackageRestrictionValue : ValueObjectBase
    {
        public long Id { get; set; }
        public long PackageRestrictionId { get; set; }
        public Guid PackageId { get; set; }
        public string Value { get; set; } = null!;
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTimeOffset? DateLastModified { get; set; }
        public Guid? UserLastModifiedId { get; set; }
        public bool Active { get; set; }
    }
}
