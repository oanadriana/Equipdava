using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.DB.Entities;

namespace Equipdava.Application.Employees.Profilles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Domain.Models.Employee>().ReverseMap();
        }
    }
}
