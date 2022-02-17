using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipdava.DB.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(30)]
        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }
    }
}
