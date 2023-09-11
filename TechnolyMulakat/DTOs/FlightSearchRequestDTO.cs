using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnolyMulakat.DTOs
{
    public class FlightSearchRequestDTO
    {
        public int? DepartureAirportId { get; set; }
        public int? ArrivalAirportId { get; set; }
        public string? DepartureDate { get; set; }
        public string? ArrivalDate { get; set; }
    }
}