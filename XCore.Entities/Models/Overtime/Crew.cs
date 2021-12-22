using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCore.Entities.Models.Overtime
{
    public class Crew
    {
        public int Id { get; set; }

        [MaxLength(5), Required]
        public string Name { get; set; }
    }
}
