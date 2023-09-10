using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Entities.Abstracts;

namespace TechnolyMulakat.Entities.Concretes
{
    public class CL_Airport : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int CityId { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(CityId))]
        public CL_City City { get; set; }
    }
}