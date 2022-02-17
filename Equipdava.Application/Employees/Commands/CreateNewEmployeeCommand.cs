using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateNewEmployeeCommand : IRequest<Employee>, IRequest<Unit>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public string City { get; set; }
    }
}
