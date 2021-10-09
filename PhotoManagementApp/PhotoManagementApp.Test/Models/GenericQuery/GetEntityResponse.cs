using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models.GenericQuery
{
    public class GetEntityResponse<TRequest>
    {
        public TRequest Request { get; set; }
        public string Message { get; set; }
    }
}
