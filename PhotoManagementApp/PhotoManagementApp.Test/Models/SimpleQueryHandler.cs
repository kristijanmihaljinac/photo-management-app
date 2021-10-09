using Common.Mediator.Core;
using Common.Mediator.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models
{
    public class SimpleQueryHandler : QueryHandler<SimpleQuery, SimpleResponse>
    {
        protected override async Task<SimpleResponse> HandleQueryAsync(SimpleQuery query,
            IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            Console.WriteLine("Test query executed");

            return new SimpleResponse()
            {
                Message = "Test query response message"
            };
        }
    }
}
