using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.Models.Rentals
{
    public class Rental
    {
        // Primary Key
        public int RentalId { get; set; }


        [Column(TypeName = "Date")]
        public DateTime DateOfRental { get; set; } = DateTime.UtcNow; // Set rental date to todays date


        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(3); // Set return date to 3 days after renting

        public bool IsReturned { get; set; }


        // Customer
        [ForeignKey("Customer")]
        public int CustomerId { get; set; } // Customer Foreign Key
        public Customer Customer { get; set; } // Customer Navigation Property

        // Media
        [ForeignKey("Media")]
        public int MediaId { get; set; } // Media Foreign Key
        public Media Media { get; set; } // Media Navigation Property
    }
}
