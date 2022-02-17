using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
