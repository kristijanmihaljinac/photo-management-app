using Common.Mediator.Core;
using Common.Mediator.Middleware;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Application.Common.Middlewares
{
    public class ValidationMiddlleware<TMessage, TResponse> : IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        private readonly IEnumerable<IValidator<TMessage>> _validators;
        public ValidationMiddlleware(IEnumerable<IValidator<TMessage>> validators)
        {
            _validators = validators;

        }
        public async Task<TResponse> RunAsync(TMessage message, IMediationContext mediationContext, CancellationToken cancellationToken, HandleMessageDelegate<TMessage, TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TMessage>(message);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }

            return await next.Invoke(message, mediationContext, cancellationToken);
        }
    }
}
