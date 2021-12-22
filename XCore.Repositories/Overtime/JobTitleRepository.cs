using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Entities.Models.Overtime;
using XCore.Repositories.Interfaces.Overtime;

namespace XCore.Repositories.Overtime
{
    public class JobTitleRepository : RepositoryBase<JobTitle>, IJobTitleRepository
    {
        public JobTitleRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<JobTitle>> GetJobTitles()
        {
            return await _context.JobTitles.ToListAsync();
        }

        public async Task<JobTitle> GetJobTitle(int id)
        {
            return await _context.JobTitles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<JobTitle> CreateJobTitle(JobTitle jobTitle)
        {
            _context.Add(jobTitle);
            await _context.SaveChangesAsync();
            return jobTitle;
        }

        public async Task UpdateJobTitle(JobTitle jobTitle)
        {
            _context.JobTitles.Update(jobTitle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobTitle(JobTitle jobTitle)
        {
            _context.JobTitles.Remove(jobTitle);
            await _context.SaveChangesAsync();
        }
    }
}
