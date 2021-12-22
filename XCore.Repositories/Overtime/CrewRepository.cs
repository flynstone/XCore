using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Entities.Models.Overtime;
using XCore.Repositories.Interfaces.Overtime;

namespace XCore.Repositories.Overtime
{
    public class CrewRepository : RepositoryBase<Crew>, ICrewRepository
    {
        public CrewRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Crew>> GetCrews()
        {
            return await _context.Crews.ToListAsync();
        }

        public async Task<Crew> GetCrew(int id)
        {
            return await _context.Crews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Crew> CreateCrew(Crew crew)
        {
            _context.Add(crew);
            await _context.SaveChangesAsync();
            return crew;
        }

        public async Task UpdateCrew(Crew crew)
        {
            _context.Crews.Update(crew);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCrew(Crew crew)
        {
            _context.Crews.Remove(crew);
            await _context.SaveChangesAsync();
        }
    }
}
