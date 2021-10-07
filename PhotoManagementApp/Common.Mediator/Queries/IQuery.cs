using Common.Mediator.Core;

namespace Common.Mediator.Queries
{
    public interface IQuery<TResult> : IMessage<TResult>
    {
    }
}
