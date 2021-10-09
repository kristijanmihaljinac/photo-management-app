using Common.Mediator.Core;
using Common.Mediator.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models.GenericQuery
{
    public class GetEntityHandler : QueryHandler<GetEntityQuery, GetEntityResponse<GetEntityQuery>>
    {
        protected override async Task<GetEntityResponse<GetEntityQuery>> HandleQueryAsync(GetEntityQuery query, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            Console.WriteLine("Test moj queric query executed");

            return new GetEntityResponse<GetEntityQuery>()
            {
                Request = query,
                Message = "Test query response message"
            };
        }
    }
}
