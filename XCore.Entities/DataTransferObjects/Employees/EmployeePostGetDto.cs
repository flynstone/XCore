using System.Collections.Generic;
using XCore.Entities.DataTransferObjects.Backups;

namespace XCore.Entities.DataTransferObjects.Employees
{
    public class EmployeePostGetDto
    {
        public List<EmployeeBackupDto> EmployeeBackups { get; set; }
        public List<BackupDto> Backups { get; set; }
    }
}
