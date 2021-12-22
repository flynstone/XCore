using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XCore.Entities;
using XCore.Entities.Models.Overtime;
using XCore.Repositories.Interfaces.Overtime;

namespace XCore.Repositories.Overtime
{
    public class RuleTypeRepository : RepositoryBase<RuleType>, IRuleTypeRepository
    {
        public RuleTypeRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RuleType>> GetRuleTypes()
        {
            return await _context.RuleTypes.ToListAsync();
        }

        public async Task<RuleType> GetRuleType(int id)
        {
            return await _context.RuleTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RuleType> CreateRuleType(RuleType ruleType)
        {
            _context.Add(ruleType);
            await _context.SaveChangesAsync();
            return ruleType;
        }

        public async Task UpdateRuleType(RuleType ruleType)
        {
            _context.RuleTypes.Update(ruleType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRuleType(RuleType ruleType)
        {
            _context.RuleTypes.Remove(ruleType);
            await _context.SaveChangesAsync();
        }
    }
}
