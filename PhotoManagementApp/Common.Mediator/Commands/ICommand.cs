using Common.Mediator.Core;

namespace Common.Mediator.Commands
{
    public interface ICommand<TResult> : IMessage<TResult>
    {

    }
}
