using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Entities.Models.Overtime;
using XCore.Repositories.Interfaces.Overtime;

namespace XCore.Repositories.Overtime
{
    public class BackupRepository : RepositoryBase<Backup>, IBackupRepository
    {
        public BackupRepository(XCoreDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Backup>> GetBackups()
        {
            return await _context.Backups.ToListAsync();
        }

        public async Task<Backup> GetBackup(int id)
        {
            return await _context.Backups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Backup> CreateBackup(Backup backup)
        {
            _context.Add(backup);
            await _context.SaveChangesAsync();
            return backup;
        }

        public async Task UpdateBackup(Backup backup)
        {
            _context.Backups.Update(backup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBackup(Backup backup)
        {
            _context.Backups.Remove(backup);
            await _context.SaveChangesAsync();
        }
    }
}
