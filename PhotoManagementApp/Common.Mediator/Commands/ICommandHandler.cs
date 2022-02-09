using Common.Mediator.Core;

namespace Common.Mediator.Commands
{
    public interface ICommandHandler<in TCommand, TResponse> : IMessageHandler<TCommand, TResponse> where TCommand : IMessage<TResponse>
    {

    }
}
