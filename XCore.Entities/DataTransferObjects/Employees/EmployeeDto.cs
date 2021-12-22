using System.Collections.Generic;

namespace XCore.Entities.DataTransferObjects.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public int CrewId { get; set; }
        public string Crew { get; set; }
        public int JobTitleId { get; set; }
        public string JobTitle { get; set; }
        public int RuleTypeId { get; set; }
        public string RuleType { get; set; }
        public List<EmployeeBackupDto> EmployeeBackups { get; set; }
    }
}
