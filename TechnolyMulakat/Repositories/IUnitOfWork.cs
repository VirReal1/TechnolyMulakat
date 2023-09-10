using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Repositories.Abstracts;

namespace TechnolyMulakat.Repositories
{
    public interface IUnitOfWork
    {
        IFlightRepository Flights { get; }

        Task<int> SaveChangesAsync();
    }
}