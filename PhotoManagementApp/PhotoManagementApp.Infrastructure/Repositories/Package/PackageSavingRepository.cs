using Common.Mediator.Core;
using PhotoManagementApp.Application.Package.CreatePackage;
using PhotoManagementApp.Application.Package.Shared.Repositories;
using PhotoManagementApp.Application.Package.UpdatePackage;
using PhotoManagementApp.Infrastructure.Mappers;

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

        public async Task<CreatePackageDto> Add(Domain.Package.Package model)
        {
            using var _dbContext = _dbContextFactory.Create();

            var dbModel = model.MapToDb();

            _dbContext.Set<Entities.Package>().Add(dbModel);

            await _dbContext.SaveChangesAsync();

            //await _mediator.HandleEventsAsync(model.DomainEvents);

            return dbModel.MapToCreatePackageDto();
        }

        public async Task Delete(long id)
        {
            using var _dbContext = _dbContextFactory.Create();

            var entity = await _dbContext.Packages.FindAsync(id);

            entity.Active = false;

            await _dbContext.SaveChangesAsync();
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
