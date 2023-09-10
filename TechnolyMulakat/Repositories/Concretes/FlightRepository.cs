using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnolyMulakat.Data;
using TechnolyMulakat.Entities.Concretes;
using TechnolyMulakat.Repositories.Abstracts;

namespace TechnolyMulakat.Repositories.Concretes
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(DataLayerContext context) : base(context)
        {

        }

        private DataLayerContext _dataLayerContext => (DataLayerContext)_context;
    }
}