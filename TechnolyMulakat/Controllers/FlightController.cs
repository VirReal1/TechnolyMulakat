using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechnolyMulakat.DTOs;
using TechnolyMulakat.Repositories;

namespace TechnolyMulakat.Controllers
{
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("flightSearch")]
        public async Task<IActionResult> GetFlightsBySearch([FromBody] FlightSearchRequestDTO searchRequest)
        {
            var flights = await _mapper.ProjectTo<FlightListDTO>(_unitOfWork.Flights.Where(l => (searchRequest.ArrivalAirportId == null || l.ArrivalAirportId == searchRequest.ArrivalAirportId)
                                                                        && (searchRequest.DepartureAirportId == null || l.DepartureAirportId == searchRequest.DepartureAirportId)
                                                                        && (searchRequest.ArrivalDate == null || l.ArrivalDate == searchRequest.ArrivalDate)
                                                                        && (searchRequest.DepartureDate == null || l.DepartureDate == searchRequest.DepartureDate))).ToListAsync();

            return Ok(flights);
        }

        [HttpGet("flightDetail/{id}")]
        public async Task<IActionResult> GetFlightDetail(int id)
        {
            var flight = await _unitOfWork.Flights.GetAsync(id);
            if (flight != null)
                return Ok(_mapper.Map<FlightDetailDTO>(flight));
            else
                return NotFound("Flight details cannot be found!");
        }
    }
}