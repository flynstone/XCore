using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Overtime;

namespace XCore.Repositories.Interfaces.Overtime
{
    public interface ICrewRepository
    {
        Task<IEnumerable<Crew>> GetCrews();
        Task<Crew> GetCrew(int id);
        Task<Crew> CreateCrew(Crew crew);
        Task UpdateCrew(Crew crew);
        Task DeleteCrew(Crew crew);
    }
}
