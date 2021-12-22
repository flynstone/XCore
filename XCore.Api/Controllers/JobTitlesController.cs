using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Repositories.Interfaces.Overtime;
using XCore.LoggerService;
using XCore.Entities.DataTransferObjects.JobTitles;
using XCore.Entities.Models.Overtime;

namespace XCore.Api.Controllers
{
    [Route("api/job-titles")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly XCoreDbContext _context;
        private readonly IJobTitleRepository _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public JobTitlesController(XCoreDbContext context, IJobTitleRepository repository, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // api/jobTitles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTitleDto>>> GetJobTitles()
        {
            try
            {
                var jobTitles = await _repository.GetJobTitles();
                return _mapper.Map<List<JobTitleDto>>(jobTitles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetJobTitles)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // api/jobTitles/5

        [HttpGet("{id:int}")]
        public async Task<ActionResult<JobTitleDto>> GetJobTitle(int id)
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == id);

            if (jobTitle == null)
            {
                _logger.LogError($"JobTitle with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                return _mapper.Map<JobTitleDto>(jobTitle);
            }
        }

        // api/jobTitles
        [HttpPost]
        public async Task<ActionResult> CreateJobTitle([FromBody] JobTitleCreationDto jobTitleCreationDto)
        {
            if (jobTitleCreationDto == null)
            {
                _logger.LogError("JobTitleCreationDto object sent from client is null.");
                return BadRequest("JobTitleCreationDto object is null.");
            }

            var jobTitle = _mapper.Map<JobTitle>(jobTitleCreationDto);

            _context.Add(jobTitle);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // api/jobTitles/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditJobTitle(int id, [FromForm] JobTitleCreationDto jobTitleCreationDto)
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == id);

            if (jobTitle == null)
            {
                _logger.LogError($"Job Title with id: {id} doesn't exist in the database");
                return NotFound();
            }

            jobTitle = _mapper.Map(jobTitleCreationDto, jobTitle);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // api/jobTitles/5
        [HttpDelete]
        public async Task<ActionResult> DeleteJobTitle(int id)
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == id);

            if (jobTitle == null)

            {
                _logger.LogError($"Job Title with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _context.Remove(jobTitle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
