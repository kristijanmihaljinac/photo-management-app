using Common.Mediator.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.UseCases
{
    public abstract class UseCaseHandler<TQuery, TResponse> : IUseCaseHandler<TQuery, TResponse> where TQuery : IMessage<TResponse>
    {
        public Task<TResponse> HandleAsync(TQuery message, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            return HandleUseCaseAsync(message, mediationContext, cancellationToken);
        }

        protected abstract Task<TResponse> HandleUseCaseAsync(TQuery query, IMediationContext mediationContext,
          CancellationToken cancellationToken);
    }
}
