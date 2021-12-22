using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace XCore.Entities.Models.Overtime
{
    public class Backup
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public virtual ICollection<EmployeeBackup> EmployeeBackups { get; set; }
    }
}
