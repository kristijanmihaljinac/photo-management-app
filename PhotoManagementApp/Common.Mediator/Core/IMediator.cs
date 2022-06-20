using Common.Mediator.Events;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Core
{
    public interface IMediator
    {
        Task<TResponse> HandleAsync<TResponse>(IMessage<TResponse> message, IMediationContext mediationContext = default(IMediationContext),
           CancellationToken cancellationToken = default(CancellationToken));

        Task HandleEventsAsync(IReadOnlyCollection<IEvent> messages, IMediationContext mediationContext = default(IMediationContext),
           CancellationToken cancellationToken = default(CancellationToken));
    }
}
