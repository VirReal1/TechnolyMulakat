using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechnolyMulakat.Data;
using TechnolyMulakat.DTOs;
using TechnolyMulakat.Repositories;

namespace TechnolyMulakat.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataLayerContext _context;
        public FlightController(IUnitOfWork unitOfWork, IMapper mapper, DataLayerContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("searchFlight")]
        public async Task<IActionResult> GetFlightsBySearch([FromBody] FlightSearchRequestDTO searchRequest)
        {
            if (searchRequest == null)
                return BadRequest();

            var flights = _unitOfWork.Flights.Where(l => (searchRequest.ArrivalAirportId == null || l.ArrivalAirportId == searchRequest.ArrivalAirportId)
                                                                        && (searchRequest.DepartureAirportId == null || l.DepartureAirportId == searchRequest.DepartureAirportId)
                                                                        && (searchRequest.ArrivalDate == null || l.ArrivalDate.Date == DateTime.ParseExact(searchRequest.ArrivalDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).Date)
                                                                        && (searchRequest.DepartureDate == null || l.DepartureDate.Date == DateTime.ParseExact(searchRequest.DepartureDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).Date));

            if (flights.Count() > 0)
                return Ok(await _mapper.ProjectTo<FlightListDTO>(flights).ToListAsync());
            else
                return NotFound();
        }

        [HttpGet("flightDetail/{id}")]
        public async Task<IActionResult> GetFlightDetail(int id)
        {
            if (id == 0)
                return BadRequest();

            var flight = await _context.Flights.Include(l => l.DepartureAirport).Include(l => l.ArrivalAirport).FirstOrDefaultAsync(l => l.Id == id);

            if (flight != null)
                return Ok(_mapper.Map<FlightDetailDTO>(flight));
            else
                return NotFound("Flight details cannot be found!");
        }
    }
}