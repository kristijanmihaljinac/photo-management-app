using Common.Mediator.Core;
using PhotoManagementApp.Application.Package.CreatePackage;
using PhotoManagementApp.Application.Package.Shared.Repositories;
using PhotoManagementApp.Application.Package.UpdatePackage;

namespace PhotoManagementApp.Infrastructure.Repositories.Package
{
    public class PackageSavingRepository : IPackageSavingRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMediator _mediator;
        public PackageSavingRepository(
            IDbContextFactory dbContextFactory,
            IMediator mediator)
        {
            _dbContextFactory = dbContextFactory;
            _mediator = mediator;
        }

        public Task<CreatePackageDto> Add(Domain.Package.Package model)
        {
            using var _dbContext = _dbContextFactory.Create();

            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdatePackageDto> Update(Domain.Package.Package model)
        {
            using var _dbContext = _dbContextFactory.Create();

            _dbContext.Set<Entities.Package>().Find(model.Id);

            //await _mediator.HandleEventsAsync(model.DomainEvents);

            throw new NotImplementedException();
        }
    }
}
