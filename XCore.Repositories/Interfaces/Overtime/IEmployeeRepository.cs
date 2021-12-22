using System.Threading.Tasks;
using XCore.Entities.Extensions;
using XCore.Entities.Models.Overtime;

namespace XCore.Repositories.Interfaces.Overtime
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesList(EmployeeParameters employeeParameters);
        Task<Employee> GetEmployee(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
    }
}
