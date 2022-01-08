using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.Models.Overtime
{
    public class Crew
    {
        public int Id { get; set; }

        [MaxLength(5), Required]
        public string Name { get; set; }
    }
}
