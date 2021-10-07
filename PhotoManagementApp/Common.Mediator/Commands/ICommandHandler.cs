using Common.Mediator.Core;

namespace Common.Mediator.Commands
{
    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand, Unit> where TCommand : IMessage<Unit>
    {

    }
}
