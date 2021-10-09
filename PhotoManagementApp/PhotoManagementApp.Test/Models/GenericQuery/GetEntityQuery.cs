using Common.Mediator.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models.GenericQuery
{
    public class GetEntityQuery :IQuery<GetEntityResponse<GetEntityQuery>>
    {
        public int EntityId { get; set; }
    }
}
