using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mediator.Queries
{
    public interface IQueryHandler<in TQuery, TResponse> : IMessageHandler<TQuery, TResponse>
        where TQuery : IMessage<TResponse>
    {
    }
}
