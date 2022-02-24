using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateNewResourceForEmployeeCommand : IRequest<EmployeeResource>, IRequest<Unit>
    {
        public int EmployeeId { get; set; }
        public int ResourceId { get; set; }
    }
}
