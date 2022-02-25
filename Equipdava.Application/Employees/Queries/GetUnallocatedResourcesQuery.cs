using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Models;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Queries
{
    public class GetUnallocatedResourcesQuery : IRequest<IEnumerable<ResourceDto>>
    {
        public int ResourceTypeId { get; set; }
    }
}
