using Common.Mediator.Core;
using Microsoft.EntityFrameworkCore;
using PhotoManagementApp.Application.Package.GetAllPackages;
using PhotoManagementApp.Application.Package.Shared.Repositories;

namespace PhotoManagementApp.Infrastructure.Repositories.Package
{
    public class PackageReadOnlyRepository //: IPackageReadOnlyRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMediator _mediator;
        public PackageReadOnlyRepository(
            IDbContextFactory dbContextFactory,
            IMediator mediator)
        {
            _dbContextFactory = dbContextFactory;
            _mediator = mediator;
        }

        //public async Task<IReadOnlyCollection<GetAllPackagesDto>> GetAll()
        //{
        //    using var _dbContext = _dbContextFactory.Create();

        //    var packages = await _dbContext
        //        .Set<Entities.Package>()
        //        .ToListAsync()
        //        .ConfigureAwait(false);



        //    return packages;

        //}
    }
}
