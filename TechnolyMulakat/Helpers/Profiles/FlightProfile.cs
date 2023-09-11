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
            CreateMap<Flight, FlightListDTO>()
                .ForMember(destination => destination.DepartureAirportName, options =>
                options.MapFrom(source => source.DepartureAirport.Name))
                .ForMember(destination => destination.ArrivalAirportName, options =>
                options.MapFrom(source => source.ArrivalAirport.Name))
                .ForMember(destination => destination.DepartureDate, options =>
                options.MapFrom(source => source.DepartureDate.ToString("dd-MM-yyyy")))
                .ForMember(destination => destination.ArrivalDate, options =>
                options.MapFrom(source => source.ArrivalDate.ToString("dd-MM-yyyy")));

            CreateMap<Flight, FlightDetailDTO>()
                .ForMember(destination => destination.DepartureAirportName, options =>
                options.MapFrom(source => source.DepartureAirport.Name))
                .ForMember(destination => destination.ArrivalAirportName, options =>
                options.MapFrom(source => source.ArrivalAirport.Name))
                .ForMember(destination => destination.DepartureDate, options =>
                options.MapFrom(source => source.DepartureDate.ToString("dd-MM-yyyy")))
                .ForMember(destination => destination.ArrivalDate, options =>
                options.MapFrom(source => source.ArrivalDate.ToString("dd-MM-yyyy")));
        }
    }
}