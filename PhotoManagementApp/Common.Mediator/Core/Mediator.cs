using Common.Mediator.Events;
using Common.Mediator.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Mediator.Core
{
    public class Mediator : IMediator
    {
        private readonly IServiceFactory _serviceFactory;

        public Mediator(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public Task<TResponse> HandleAsync<TResponse>(IMessage<TResponse> message,
            IMediationContext mediationContext = default(MediationContext), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (mediationContext == null)
            {
                mediationContext = MediationContext.Default;
            }

            var targetHandler = GetTargetHandler<TResponse>(message.GetType());

            var result = InvokeInstanceAsync(_serviceFactory.GetInstance(targetHandler), message, targetHandler, mediationContext, cancellationToken);

            return result;
        }

        public Task HandleEventsAsync(IReadOnlyCollection<IEvent> messages, IMediationContext mediationContext = null, CancellationToken cancellationToken = default)
        {
            if (mediationContext == null)
            {
                mediationContext = MediationContext.Default;
            }

            var targetHandlers = messages.Select(message => new Tuple<Type, IEvent>(GetTargetHandler<Unit>(message.GetType()), message));


            Parallel.ForEach(targetHandlers,
                 handler =>
                 InvokeInstanceAsync(_serviceFactory.GetInstance(handler.Item1), handler.Item2, handler.Item1, mediationContext, cancellationToken));

            return Task.CompletedTask;
        }

        private Type GetTargetHandler<TResponse>(Type targetType)
        {
            return typeof(IMessageProcessor<,>).MakeGenericType(targetType, typeof(TResponse));
        }

        private Task<TResponse> InvokeInstanceAsync<TResponse>(object instance, IMessage<TResponse> message, Type targetHandler,
            IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var method = instance.GetType()
                .GetTypeInfo()
                .GetMethod(nameof(IMessageProcessor<IMessage<TResponse>, TResponse>.HandleAsync));

            if (method == null)
            {
                throw new ArgumentException($"{instance.GetType().Name} is not a known {targetHandler.Name}",
                    instance.GetType().FullName);
            }

            return (Task<TResponse>)method.Invoke(instance, new object[] { message, mediationContext, cancellationToken });
        }
    }
}
