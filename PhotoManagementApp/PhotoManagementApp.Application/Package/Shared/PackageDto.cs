namespace PhotoManagementApp.Application.Package.Shared
{
    public class PackageDto
    {
        public long Id { get; set; }
        public string Code { get;  set; }
        public string Name { get; private set; }
        public DateTimeOffset DateCreated { get;  set; }
        public Guid UserCreatedId { get;  set; }
        public DateTimeOffset? DateLastModified { get;  set; }
        public Guid? UserLastModifiedId { get;  set; }
        public bool Active { get;  set; }
    }
}
