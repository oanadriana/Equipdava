using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.Application.Employees.Models;
using Equipdava.Domain.Models;

namespace Equipdava.Application.Employees.Profilles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Resource, DB.Entities.Resource>().ReverseMap();

            CreateMap<DB.Entities.Resource, ResourceDto>()
                .ForMember(dest => dest.ResourceType,
                    opt =>
                        opt.MapFrom(src => src.ResourceType.Name.ToString()))
                .ForMember(dest => dest.Id,
                    opt =>
                        opt.MapFrom(src => src.Id))
                .ReverseMap();

            //CreateMap<DB.Entities.Resource, AllocatedResource>()
            //    .ForMember(dest => dest.Brand, opt =>
            //        opt.MapFrom(src => src.Brand))
            //    .ForMember(dest => dest.Model, opt =>
            //        opt.MapFrom(src => src.Model))
            //    .ForMember(dest => dest.ResourceTypeName, opt =>
            //        opt.MapFrom(src => src.ResourceType.Name)).ReverseMap();
        }
    }
}
