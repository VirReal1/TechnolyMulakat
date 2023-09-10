using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Data;
using TechnolyMulakat.Repositories.Abstracts;
using TechnolyMulakat.Repositories.Concretes;

namespace TechnolyMulakat.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataLayerContext _context;
        private IFlightRepository _flights;

        public UnitOfWork(DataLayerContext context)
        {
            _context = context;
        }

        public IFlightRepository Flights
        {
            get
            {
                _flights ??= new FlightRepository(_context);

                return _flights;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}