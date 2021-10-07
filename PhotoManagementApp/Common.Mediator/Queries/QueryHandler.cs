using Common.Mediator.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Queries
{
    public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IMessage<TResponse>
    {
        public Task<TResponse> HandleAsync(TQuery message, IMediationContext mediationContext,
            CancellationToken cancellationToken)
        {
            return HandleQueryAsync(message, mediationContext, cancellationToken);
        }

        protected abstract Task<TResponse> HandleQueryAsync(TQuery query, IMediationContext mediationContext,
            CancellationToken cancellationToken);
    }
}
