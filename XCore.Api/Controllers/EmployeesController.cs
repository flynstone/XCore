using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using XCore.Entities;
using XCore.Repositories.Interfaces.Overtime;
using XCore.Entities.DataTransferObjects.Employees;
using XCore.Entities.Extensions;
using XCore.Entities.Models.Overtime;

namespace XCore.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly XCoreDbContext _context;
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeesController(XCoreDbContext context, IEmployeeRepository repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<EmployeeDto>> GetEmployees([FromQuery] EmployeeParameters employeeParameters)
        {
            var employeesFromDb = await _repository.GetEmployeesList(employeeParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(employeesFromDb.MetaData));

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            return Ok(employeesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _repository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee([FromBody] EmployeeCreationDto employeeCreationDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreationDto);
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("Not a valid employee id.");
            }

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("crews")]
        public IEnumerable<Crew> GetCrews()
        {
            return _context.Crews.ToList();
        }

        [HttpGet("job-titles")]
        public IEnumerable<JobTitle> GetJobTitles()
        {
            return _context.JobTitles.ToList();
        }

        [HttpGet("rule-types")]
        public IEnumerable<RuleType> GetRuleTypes()
        {
            return _context.RuleTypes.ToList();
        }

        [HttpGet("backups")]
        public IEnumerable<Backup> GetBackups()
        {
            return _context.Backups.ToList();
        }
    }
}
