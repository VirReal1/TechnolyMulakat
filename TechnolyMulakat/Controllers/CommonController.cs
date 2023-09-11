using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnolyMulakat.Data;
using TechnolyMulakat.DTOs;
using TechnolyMulakat.Repositories.Abstracts;

namespace TechnolyMulakat.Controllers
{
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly DataLayerContext _context;
        public IMapper _mapper { get; }
        public CommonController(DataLayerContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("airports")]
        public async Task<IActionResult> GetAirports()
        {
            return Ok(await _mapper.ProjectTo<CodeListModel>(_context.Airports).ToListAsync());
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _mapper.ProjectTo<CodeListModel>(_context.Cities).ToListAsync());
        }
    }
}