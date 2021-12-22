using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Overtime;

namespace XCore.Repositories.Interfaces.Overtime
{
    public interface IRuleTypeRepository
    {
        Task<IEnumerable<RuleType>> GetRuleTypes();
        Task<RuleType> GetRuleType(int id);
        Task<RuleType> CreateRuleType(RuleType ruleType);
        Task UpdateRuleType(RuleType ruleType);
        Task DeleteRuleType(RuleType ruleType);
    }
}
