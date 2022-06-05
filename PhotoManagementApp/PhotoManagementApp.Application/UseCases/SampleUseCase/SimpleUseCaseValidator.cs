using Common.Mediator.Core;
using Common.Mediator.Middleware;
using FluentValidation;

namespace PhotoManagementApp.Application.UseCases.SampleUseCase
{
    public class SimpleUseCaseValidator : AbstractValidator<SampleUseCase>
    {
        public SimpleUseCaseValidator()
        {
            RuleFor(x => x.Sample)
                .NotEmpty().WithMessage("Sample is required");
        }
    }
}
