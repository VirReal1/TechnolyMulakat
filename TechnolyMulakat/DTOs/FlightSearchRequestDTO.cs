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
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
    }
}