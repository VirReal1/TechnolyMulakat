using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnolyMulakat.DTOs
{
    public class FlightListDTO
    {
        public int Id { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string Apron { get; set; }
    }
}