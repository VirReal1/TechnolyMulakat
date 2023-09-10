using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Entities.Abstracts;
using TechnolyMulakat.Helpers.Attributes;

namespace TechnolyMulakat.Entities.Concretes
{
    public class Flight : AuditableEntity, IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DepartureAirportId { get; set; }

        [Required]
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }

        [DateGreaterThan("DepartureDate")]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Aircraft type name cannot be longer than 255 characters")]
        public string AircraftType { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Apron name cannot be longer than 255 characters")]
        public string Apron { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Pilot name cannot be longer than 255 characters")]
        public string PilotName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Co-pilot name cannot be longer than 255 characters")]
        public string CoPilotName { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(ArrivalAirportId))]
        public CL_Airport ArrivalAirport { get; set; }

        [ForeignKey(nameof(DepartureAirportId))]
        public CL_Airport DepartureAirport { get; set; }
    }
}