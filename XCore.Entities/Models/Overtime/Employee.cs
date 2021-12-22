using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.Models.Overtime
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string HomePhone { get; set; }

        [MaxLength(20)]
        public string CellPhone { get; set; }


        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //
        //           Foreign Table Relations             //
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //

        public int CrewId { get; set; }
        public int JobTitleId { get; set; }
        public int RuleTypeId { get; set; }


        [ForeignKey("CrewId")]
        public virtual Crew Crew { get; set; }

        [ForeignKey("JobTitleId")]
        public virtual JobTitle JobTitle { get; set; }

        [ForeignKey("RuleTypeId")]
        public virtual RuleType RuleType { get; set; }


        public virtual ICollection<EmployeeBackup> EmployeeBackups { get; set; }
    }
}
