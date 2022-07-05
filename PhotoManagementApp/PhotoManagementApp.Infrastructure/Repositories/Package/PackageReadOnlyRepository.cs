using Dapper;
using PhotoManagementApp.Application.Package.GetAllPackages;
using PhotoManagementApp.Application.Package.Shared.Repositories;
using System.Data;

namespace PhotoManagementApp.Infrastructure.Repositories.Package
{
    public class PackageReadOnlyRepository : IPackageReadOnlyRepository
    {
        private readonly IDbConnection _dbConnection;
        public PackageReadOnlyRepository(
            IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<GetAllPackagesDto>> GetAll()
        {
            var response = await _dbConnection.QueryAsync<GetAllPackagesDto>($"SELECT * FROM [dbo].[GetAllPackagesQueryView]");

            return response;
        }


    }
}
