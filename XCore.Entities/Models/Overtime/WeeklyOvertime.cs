using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.Models.Overtime
{
    public class WeeklyOvertime
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string Crew { get; set; }
        public string JobTitle { get; set; }
        public string RuleType { get; set; }

        [DataType(DataType.Date), Display(Name = "Overtime for Week Ending: ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime WeekEnding { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal WorkedOvertime { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal RefusedOvertime { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TotalOvertime
        {
            get
            {
                return WorkedOvertime + RefusedOvertime;
            }
        }
    }
}
