using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class DeleteResourceCommand : IRequest<Unit>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ResourceTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
