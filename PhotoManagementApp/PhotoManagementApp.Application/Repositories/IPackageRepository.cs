namespace PhotoManagementApp.Application.Repositories
{
    public interface IPackageRepository
    {
        Task<int> GetPackageCount();
    }
}
