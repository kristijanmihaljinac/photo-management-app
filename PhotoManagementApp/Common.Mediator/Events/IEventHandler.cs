using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Mediator.Events
{
    public interface IEventHandler<in TEvent> : IMessageHandler<TEvent, Unit> where TEvent : IMessage<Unit>
    {
    }
}
