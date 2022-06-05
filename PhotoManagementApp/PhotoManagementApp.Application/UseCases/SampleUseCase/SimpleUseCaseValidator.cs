using Common.Mediator.Core;
using Common.Mediator.Middleware;

namespace PhotoManagementApp.Application.UseCases.SampleUseCase
{
    public class SimpleUseCaseValidator : IMiddleware<SampleUseCase, bool>
    {
        public async Task<bool> RunAsync(SampleUseCase message, IMediationContext mediationContext, CancellationToken cancellationToken, HandleMessageDelegate<SampleUseCase, bool> next)
        {
            Console.WriteLine("Validation hit");

            return await next.Invoke(message, mediationContext, cancellationToken);
        }
    }
}
