using Common.Mediator.Core;
using Common.Mediator.UseCases;

namespace PhotoManagementApp.Application.Package.CreatePackage
{
    internal class CreatePackageUseCaseHandler : UseCaseHandler<CreatePackageUseCase, CreatePackageDto>
    {
        public CreatePackageUseCaseHandler()
        {

        }

        protected override Task<CreatePackageDto> HandleUseCaseAsync(CreatePackageUseCase useCase, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
