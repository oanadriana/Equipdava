using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipdava.Domain.Models
{
    public class EmployeeResource
    {
        public int Id { get; set; }

        public DateTime AllocatedOn { get; set; }

        public int EmployeeId { get; set; }

        public int ResourceId { get; set; }
    }
}
