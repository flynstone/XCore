using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.Models.Overtime
{
    public class RuleType
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }
    }
}
