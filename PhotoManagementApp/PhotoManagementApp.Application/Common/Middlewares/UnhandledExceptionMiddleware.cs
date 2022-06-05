using Common.Mediator.Core;
using Common.Mediator.Middleware;

namespace PhotoManagementApp.Application.Common.Middlewares
{
    public class UnhandledExceptionMiddleware<TMessage, TResponse> : IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        public async Task<TResponse> RunAsync(TMessage message, IMediationContext mediationContext, CancellationToken cancellationToken, HandleMessageDelegate<TMessage, TResponse> next)
        {
            try
            {
                return await next.Invoke(message, mediationContext, cancellationToken);
            }
            catch (Exception ex)
            {
                var requestName = typeof(TMessage).Name;

                throw;
            }
        }
    }
}
