using Common.Mediator.Core;
using Common.Mediator.UseCases;
using PhotoManagementApp.Application.Repositories;

namespace PhotoManagementApp.Application.UseCases.SampleUseCase
{
    public class SampleUseCaseHandler : UseCaseHandler<SampleUseCase, bool>
    {
        private readonly IPackageRepository _packageRepository;
        public SampleUseCaseHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }
        protected override async Task<bool> HandleUseCaseAsync(SampleUseCase useCase, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var count = await _packageRepository.GetPackageCount();

            var thisIsSparta = useCase.Sample;

            return true;
        }
    }
}
