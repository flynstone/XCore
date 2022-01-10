using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCore.Entities.DataTransferObjects.Rentals
{
    public class RentalForCreationDto
    {
        [Column(TypeName = "Date")]
        public DateTime DateOfRental { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        public int CustomerId { get; set; }
        public int MediaId { get; set; }

        public bool isReturned = false;
    }
}
