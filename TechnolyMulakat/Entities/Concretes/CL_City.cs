using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Entities.Abstracts;

namespace TechnolyMulakat.Entities.Concretes
{
    public class CL_City : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //Navigation Lists
        public ICollection<CL_Airport> Airports { get; set; }
    }
}