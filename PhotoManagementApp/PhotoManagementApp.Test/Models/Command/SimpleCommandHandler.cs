using Common.Mediator.Commands;
using Common.Mediator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models.Command
{
    public class SimpleCommandHandler : CommandHandler<SimpleCommand, SimpleResponse>
    {
        protected override Task<SimpleResponse> HandleCommandAsync(SimpleCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SimpleResponse() { Message = "moja porukica"});
        }
    }
}
