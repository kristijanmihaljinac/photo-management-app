using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Commands
{
    public abstract class CommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> where TCommand : IMessage<TResponse>
    {
        public Task<TResponse> HandleAsync(TCommand message, IMediationContext mediationContext,
            CancellationToken cancellationToken)
        {
            return HandleCommandAsync(message, mediationContext, cancellationToken);
        }

        protected abstract Task<TResponse> HandleCommandAsync(TCommand command, IMediationContext mediationContext,
            CancellationToken cancellationToken);
    }
}
