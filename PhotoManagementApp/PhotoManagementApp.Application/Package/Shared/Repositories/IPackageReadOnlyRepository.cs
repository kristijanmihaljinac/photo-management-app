using PhotoManagementApp.Application.Package.GetAllPackages;

namespace PhotoManagementApp.Application.Package.Shared.Repositories
{
    public interface IPackageReadOnlyRepository
    {
        Task<IEnumerable<GetAllPackagesDto>> GetAll();
    }
}
