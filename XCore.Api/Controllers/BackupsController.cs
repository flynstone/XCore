using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.LoggerService;
using XCore.Entities.Models.Overtime;
using XCore.Entities.DataTransferObjects.Backups;

namespace XCore.Api.Controllers
{
    [Route("api/backups")]
    [ApiController]
    public class BackupsController : ControllerBase
    {
        private readonly XCoreDbContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BackupsController(XCoreDbContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // api/backups
        [HttpGet]
        public async Task<ActionResult<List<BackupDto>>> GetBackups()
        {
            try
            {
                var backups = await _context.Backups.ToListAsync();
                return _mapper.Map<List<BackupDto>>(backups);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetBackups)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // api/backups/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BackupDto>> GetRuleType(int id)
        {
            var backup = await _context.Backups.FirstOrDefaultAsync(x => x.Id == id);

            if (backup == null)
            {
                _logger.LogError($"Backup with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                return _mapper.Map<BackupDto>(backup);
            }
        }

        // api/backups
        [HttpPost]
        public async Task<ActionResult> CreateBackup([FromBody] BackupCreationDto backupCreationDto)
        {
            if (backupCreationDto == null)
            {
                _logger.LogError("BackupCreationDto object sent from client is null.");
                return BadRequest("BackupCreationDto object is null.");
            }

            var backup = _mapper.Map<Backup>(backupCreationDto);

            _context.Add(backup);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // api/backups/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditBackup(int id, [FromBody] BackupCreationDto backupCreationDto)
        {
            var backup = _mapper.Map<Backup>(backupCreationDto);
            backup.Id = id;

            _context.Entry(backup).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }



        // api/backups/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBackup(int id)

        {
            var backup = await _context.Backups.FirstOrDefaultAsync(x => x.Id == id);

            if (backup == null)
            {
                _logger.LogError($"Backup with id: {id} doesn't exist in the database");
                return NotFound();
            }

            _context.Remove(backup);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
