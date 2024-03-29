﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Models;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateNewResourceForEmployeeCommand : IRequest<AllocatedResource>, IRequest<Unit>
    {
        public int EmployeeId { get; set; }
        public int ResourceId { get; set; }
    }
}
