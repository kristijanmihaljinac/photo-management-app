using Common.Mediator.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Test.Models.Command
{
    public class SimpleCommand : ICommand<SimpleResponse>
    {
        public string Name { get; set; }
    }
}
