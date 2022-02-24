using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.Entities;
using AutoMapper;
using Equipdava.DB.Entities;

namespace Equipdava.Application.Employees.Profilles
{
    public class EmployeeResourceProfile : Profile
    {
        public EmployeeResourceProfile()
        {
            CreateMap<EmployeeResource, Domain.Models.EmployeeResource>().ReverseMap(); 
        }
    }
}
