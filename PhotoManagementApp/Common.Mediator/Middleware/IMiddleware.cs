using Common.Mediator.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Middleware
{
    public delegate Task<TResponse> HandleMessageDelegate<in TMessage, TResponse>(TMessage message, IMediationContext mediationContext, CancellationToken cancellationToken);

    public interface IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        //public IMiddleware<TMessage, TResponse> Next { get; set; }

        Task<TResponse> RunAsync(TMessage message, IMediationContext mediationContext,
            CancellationToken cancellationToken, HandleMessageDelegate<TMessage, TResponse> next);
    }
}
