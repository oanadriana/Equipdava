//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Equipdava.Application.Employees.Models;
//using Equipdava.Domain.Models;

//namespace Equipdava.Application.Employees.Profilles
//{
//    public class ResourceTypeProfile : Profile
//    {
//        public ResourceTypeProfile()
//        {
//            CreateMap<DB.Entities.ResourceType, ResourceType>().ReverseMap();
//            CreateMap<DB.Entities.ResourceType, AllocatedResource>()
//                .ForMember(dest => dest.ResourceTypeName, opt =>
//                    opt.MapFrom(src => src.Name)).ReverseMap();
//        }
//    }
//}
