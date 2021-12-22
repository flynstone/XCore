using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.LoggerService;
using XCore.Entities.DataTransferObjects.RuleTypes;
using XCore.Entities.Models.Overtime;

namespace XCore.Api.Controllers
{
    [Route("api/rule-types")]
    [ApiController]
    public class RuleTypesController : ControllerBase
    {
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RuleTypesController(XCoreDbContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // api/ruleTypes
        [HttpGet]
        public async Task<ActionResult<List<RuleTypeDto>>> GetRuleTypes()
        {
            try
            {
                var ruleTypes = await _context.RuleTypes.ToListAsync();
                return _mapper.Map<List<RuleTypeDto>>(ruleTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetRuleTypes)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // api/ruleTypes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RuleTypeDto>> GetRuleType(int id)
        {
            var ruleType = await _context.RuleTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (ruleType == null)
            {
                _logger.LogError($"RuleType with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                return _mapper.Map<RuleTypeDto>(ruleType);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateRuleType([FromBody] RuleTypeCreationDto ruleTypeCreationDto)
        {
            if (ruleTypeCreationDto == null)
            {
                _logger.LogError("RuleTypeCreationDto object sent from client is null.");
                return BadRequest("RuleTypeCreationDto object is null.");
            }

            var ruleType = _mapper.Map<RuleType>(ruleTypeCreationDto);

            _context.Add(ruleType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // api/ruleTypes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditRuleType(int id, [FromForm] RuleTypeCreationDto ruleTypeCreationDto)
        {
            var ruleType = await _context.RuleTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (ruleType == null)
            {
                _logger.LogError($"RuleType with id: {id} doesn't exist in the database");
                return NotFound();
            }

            ruleType = _mapper.Map(ruleTypeCreationDto, ruleType);

            await _context.SaveChangesAsync();
            return NoContent();
        }



        // api/ruleTypes/5
        [HttpDelete]
        public async Task<ActionResult> DeleteRuleType(int id)

        {
            var ruleType = await _context.RuleTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (ruleType == null)
            {
                _logger.LogError($"RuleType with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _context.Remove(ruleType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
