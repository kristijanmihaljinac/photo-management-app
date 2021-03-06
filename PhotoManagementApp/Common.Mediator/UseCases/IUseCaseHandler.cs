using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mediator.UseCases
{
    public interface IUseCaseHandler<in TQuery, TResponse> : IMessageHandler<TQuery, TResponse>
        where TQuery : IMessage<TResponse>
    {

    }
}
