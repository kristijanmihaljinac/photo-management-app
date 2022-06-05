using Common.Mediator.Queries;
using Common.Mediator.UseCases;

namespace PhotoManagementApp.Application.UseCases.SampleUseCase
{
    public class SampleUseCase : IUseCase<bool>
    {
        public string Sample { get; set; }
    }
}
