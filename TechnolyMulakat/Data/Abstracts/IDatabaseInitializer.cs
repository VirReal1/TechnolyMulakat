using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnolyMulakat.Data.Abstracts
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}