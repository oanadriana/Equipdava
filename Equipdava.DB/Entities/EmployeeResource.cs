using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Domain.Models;

namespace Equipdava.DB.Entities
{
    public class EmployeeResource
    {
        [Key]
        public int Id { get; set; }

        public DateTime AllocatedOn { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("ResourceId")]
        public Resource Resource { get; set; }
        public int ResourceId { get; set; }
    }
}
