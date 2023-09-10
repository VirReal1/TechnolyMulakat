using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TechnolyMulakat.DTOs;
using TechnolyMulakat.Entities.Concretes;

namespace TechnolyMulakat.Helpers.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightListDTO>();
            CreateMap<Flight, FlightDetailDTO>();
        }
    }
}