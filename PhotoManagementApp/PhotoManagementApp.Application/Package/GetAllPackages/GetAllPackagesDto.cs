namespace PhotoManagementApp.Application.Package.GetAllPackages
{
    public class GetAllPackagesDto : Package.Shared.PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
