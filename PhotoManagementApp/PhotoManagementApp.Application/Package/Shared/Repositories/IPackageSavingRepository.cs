using PhotoManagementApp.Application.Package.CreatePackage;
using PhotoManagementApp.Application.Package.UpdatePackage;

namespace PhotoManagementApp.Application.Package.Shared.Repositories
{
    public interface IPackageSavingRepository
    {
        Task<CreatePackageDto> Add(Domain.Package.Package model);
        Task<UpdatePackageDto> Update(Domain.Package.Package model);
        Task Delete(long id);
    }
}
