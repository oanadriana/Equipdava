using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Models;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateResourceCommand : IRequest<IEnumerable<Resource>>, IRequest<Unit>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ResourceTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
