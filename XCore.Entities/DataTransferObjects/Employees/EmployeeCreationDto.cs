namespace XCore.Entities.DataTransferObjects.Employees
{
    public class EmployeeCreationDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public int CrewId { get; set; }
        public int JobTitleId { get; set; }
        public int RuleTypeId { get; set; }
    }
}
