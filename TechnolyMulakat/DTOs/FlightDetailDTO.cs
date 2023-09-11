using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnolyMulakat.DTOs
{
    public class FlightDetailDTO
    {
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string AircraftType { get; set; }
        public string Apron { get; set; }
        public string PilotName { get; set; }
        public string CoPilotName { get; set; }
    }
}