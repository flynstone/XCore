using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.DataTransferObjects.Rentals
{
    public class RentalForUpdateDto
    {
        [Column(TypeName = "Date")]
        public DateTime DateOfRental { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        public int CustomerId { get; set; }
        public int MediaId { get; set; }

        public bool isReturned { get; set; }
    }
}
