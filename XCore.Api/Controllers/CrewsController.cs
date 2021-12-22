using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Repositories.Interfaces.Overtime;
using XCore.LoggerService;
using XCore.Entities.DataTransferObjects.Crews;
using XCore.Entities.Models.Overtime;
using Microsoft.AspNetCore.Authorization;

namespace XCore.Api.Controllers
{
    [Route("api/crews")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        private readonly XCoreDbContext _context;
        private readonly ICrewRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CrewsController(XCoreDbContext context, ICrewRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // api/crews
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCrews()
        {
            var crews = await _repository.GetCrews();
            var crewDto = _mapper.Map<IEnumerable<CrewDto>>(crews);
            return Ok(crewDto);
        }

        // api/crews/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CrewDto>> GetCrew(int id)
        {
            var crew = await _repository.GetCrew(id);

            if (crew == null)
            {
                _logger.LogError($"Crew with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                return _mapper.Map<CrewDto>(crew);
            }
        }

        // api/crews
        [HttpPost]
        public async Task<ActionResult> CreateCrew([FromBody] CrewCreationDto crewCreationDto)
        {
            if (crewCreationDto == null)
            {
                _logger.LogError("CrewCreationDto object sent from client is null.");
                return BadRequest("CrewCreationDto object is null.");
            }

            var crew = _mapper.Map<Crew>(crewCreationDto);

            _context.Add(crew);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // api/crews/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditCrew(int id, [FromForm] CrewCreationDto crewCreationDto)
        {
            var crew = await _context.Crews.FirstOrDefaultAsync(x => x.Id == id);

            if (crew == null)
            {
                _logger.LogError($"Crew with id: {id} doesn't exist in the database");
                return NotFound();
            }

            crew = _mapper.Map(crewCreationDto, crew);

            await _context.SaveChangesAsync();
            return NoContent();
        }



        // api/crews/5
        [HttpDelete]
        public async Task<ActionResult> DeleteCrew(int id)

        {
            var crew = await _context.Crews.FirstOrDefaultAsync(x => x.Id == id);

            if (crew == null)
            {
                _logger.LogError($"Crew with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _context.Remove(crew);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
