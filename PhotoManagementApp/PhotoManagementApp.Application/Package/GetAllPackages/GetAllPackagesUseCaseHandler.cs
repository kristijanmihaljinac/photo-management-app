using Common.Mediator.Core;
using Common.Mediator.UseCases;
using PhotoManagementApp.Application.Package.Shared.Repositories;

namespace PhotoManagementApp.Application.Package.GetAllPackages
{
    public class GetAllPackagesUseCaseHandler : UseCaseHandler<GetAllPackagesUseCase, IEnumerable<GetAllPackagesDto>>
    {
        private readonly IPackageReadOnlyRepository _packageReadOnlyRepository;
        public GetAllPackagesUseCaseHandler(
            IPackageReadOnlyRepository packageReadOnlyRepository)
        {
            _packageReadOnlyRepository = packageReadOnlyRepository;
        }

        protected override async Task<IEnumerable<GetAllPackagesDto>> HandleUseCaseAsync(GetAllPackagesUseCase useCase, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var result = await _packageReadOnlyRepository.GetAll();

            return result;
        }
    }
}
