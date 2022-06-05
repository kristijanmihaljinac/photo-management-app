using Common.Mediator.Core;
using Common.Mediator.Middleware;

namespace PhotoManagementApp.Application.Common.Middlewares
{
    internal class PerformanceMiddleware<TMessage, TResponse> : IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        public async Task<TResponse> RunAsync(TMessage message, IMediationContext mediationContext, CancellationToken cancellationToken, HandleMessageDelegate<TMessage, TResponse> next)
        {
            Console.WriteLine("Message pre logged using middleware 1");
            var result = await next.Invoke(message, mediationContext, cancellationToken);
            Console.WriteLine("Message post logged using middleware 1");

            return result;
        }
    }
}
