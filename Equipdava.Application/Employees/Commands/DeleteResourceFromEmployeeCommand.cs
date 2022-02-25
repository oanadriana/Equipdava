using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class DeleteResourceFromEmployeeCommand : IRequest<Unit>
    {
        public int ResourceId { get; set; }
    }
}
