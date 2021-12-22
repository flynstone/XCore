using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Entities.Extensions;
using XCore.Entities.Models.Overtime;
using XCore.Repositories.Interfaces.Overtime;

namespace XCore.Repositories.Overtime
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(XCoreDbContext context) : base(context)
        {
        }


        // ~~~~~~~~~~~~~~~ Get Paged Employees List ~~~~~~~~~~~~~~~ //
        public async Task<PagedList<Employee>> GetEmployeesList(EmployeeParameters employeeParameters)
        {
            var employees = await _context.Employees
                .Include(e => e.Crew)
                .Include(e => e.JobTitle)
                .Include(e => e.RuleType)
                .Skip((employeeParameters.PageIndex -1) * employeeParameters.PageSize)
                .Take(employeeParameters.PageSize)
                .ToListAsync();

            return PagedList<Employee>.ToPagedList(employees, employeeParameters.PageIndex, employeeParameters.PageSize);
        }

        // ~~~~~~~~~~~~~~~ Get Employee By Id ~~~~~~~~~~~~~~~ //
        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees
                .Include(x => x.Crew)
                .Include(x => x.JobTitle)
                .Include(x => x.RuleType)
                .Include(eb => eb.EmployeeBackups).ThenInclude(b => b.Backup)
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        // ~~~~~~~~~~~~~~~ Create Employee ~~~~~~~~~~~~~~~ //
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        // ~~~~~~~~~~~~~~~ Edit Employee ~~~~~~~~~~~~~~~ //
        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        // ~~~~~~~~~~~~~~~ Delete Employee ~~~~~~~~~~~~~~~ //
        public async Task DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
