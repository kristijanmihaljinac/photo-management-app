using Microsoft.EntityFrameworkCore;
using PhotoManagementApp.Application.Repositories;

namespace PhotoManagementApp.Infrastructure.Repositories.Package
{
    public class PackageRepository : IPackageRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        public PackageRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<int> GetPackageCount()
        {
            using var dbContext = _dbContextFactory.Create();

            var count = await dbContext.Packages.CountAsync();

            return count;
        }
    }
}
