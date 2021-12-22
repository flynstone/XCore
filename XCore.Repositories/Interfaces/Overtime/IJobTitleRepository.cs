using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Overtime;

namespace XCore.Repositories.Interfaces.Overtime
{
    public interface IJobTitleRepository
    {
        Task<IEnumerable<JobTitle>> GetJobTitles();
        Task<JobTitle> GetJobTitle(int id);
        Task<JobTitle> CreateJobTitle(JobTitle jobTitle);
        Task UpdateJobTitle(JobTitle jobTitle);
        Task DeleteJobTitle(JobTitle jobTitle);
    }
}
