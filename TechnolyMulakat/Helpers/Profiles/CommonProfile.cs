using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TechnolyMulakat.DTOs;
using TechnolyMulakat.Entities.Concretes;

namespace TechnolyMulakat.Helpers.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<CL_City, CodeListModel>();
            CreateMap<CL_Airport, CodeListModel>();
        }
    }
}