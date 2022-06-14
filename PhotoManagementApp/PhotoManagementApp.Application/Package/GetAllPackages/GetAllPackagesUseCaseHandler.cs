using Common.Mediator.Core;
using Common.Mediator.UseCases;

namespace PhotoManagementApp.Application.Package.GetAllPackages
{
    public class GetAllPackagesUseCaseHandler : UseCaseHandler<GetAllPackagesUseCase, List<GetAllPackagesDto>>
    {
        protected override Task<List<GetAllPackagesDto>> HandleUseCaseAsync(GetAllPackagesUseCase useCase, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
