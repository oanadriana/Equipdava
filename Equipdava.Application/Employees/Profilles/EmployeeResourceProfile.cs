using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.Entities;
using AutoMapper;
using Equipdava.Application.Employees.Models;
using Equipdava.DB.Entities;

namespace Equipdava.Application.Employees.Profilles
{
    public class EmployeeResourceProfile : Profile
    {
        public EmployeeResourceProfile()
        {
            CreateMap<EmployeeResource, Domain.Models.EmployeeResource>().ReverseMap();

            CreateMap<EmployeeResource, AllocatedResource>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt =>
                    opt.MapFrom(src => src.Employee.FirstName))
                .ForMember(dest => dest.LastName, opt =>
                    opt.MapFrom(src => src.Employee.LastName))
                .ForMember(dest => dest.ResourceTypeName, opt =>
                    opt.MapFrom(src => src.Resource.ResourceType.Name))
                .ForMember(dest => dest.AllocatedOn, opt => 
                    opt.MapFrom(src => src.AllocatedOn))
                .ForMember(dest => dest.Brand, opt =>
                    opt.MapFrom(src => src.Resource.Brand))
                .ForMember(dest => dest.Model, opt =>
                    opt.MapFrom(src => src.Resource.Model)).ReverseMap();
        }
    }
}
