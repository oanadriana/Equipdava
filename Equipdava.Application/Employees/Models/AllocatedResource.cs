using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipdava.Application.Employees.Models
{
    public class AllocatedResource 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AllocatedOn { get; set; }
        public string ResourceTypeName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
