using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Entities.Abstracts;

namespace TechnolyMulakat.Entities.Concretes
{
    public class AuditableEntity : IAuditableEntity
    {
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}