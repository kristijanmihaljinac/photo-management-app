using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Events
{
    public abstract class EventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IMessage<Unit>
    {
        public async Task<Unit> HandleAsync(TEvent message, IMediationContext mediationContext,
            CancellationToken cancellationToken)
        {
            await HandleEventAsync(message, mediationContext, cancellationToken);
            return Unit.Result;
        }

        protected abstract Task HandleEventAsync(TEvent @event, IMediationContext mediationContext,
            CancellationToken cancellationToken);
    }
}
