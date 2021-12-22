using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Overtime;

namespace XCore.Repositories.Interfaces.Overtime
{
    public interface IBackupRepository
    {
        Task<IEnumerable<Backup>> GetBackups();
        Task<Backup> GetBackup(int id);
        Task<Backup> CreateBackup(Backup backup);
        Task UpdateBackup(Backup backup);
        Task DeleteBackup(Backup backup);
    }
}
