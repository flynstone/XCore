using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace XCore.Entities.DataTransferObjects.Rentals
{
    public class RentalDto
    {
        public int RentalId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfRental { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }

        // Customer Foreign Key
        public int CustomerId { get; set; }
        public string Customer { get; set; }

        // Media Foreign Key
        public int MediaId { get; set; }
        public string Media { get; set; }
    }
}
