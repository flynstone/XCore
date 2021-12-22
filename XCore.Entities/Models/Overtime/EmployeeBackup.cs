using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.Models.Overtime
{
    public class EmployeeBackup
    {
        public int EmployeeId { get; set; }
        public int BackupId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("BackupId")]
        public virtual Backup Backup { get; set; }
    }
}
