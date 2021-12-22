using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.Models.Rentals
{
    public class Customer
    {
        // Primary Key
        public int CustomerId { get; set; }

        [MaxLength(100)] // String Object Maximum Character Length (used on database table creation)
        public string LastName { get; set; } // Customer's Last Name

        [MaxLength(100)] // String Object Maximum Character Length (used on database table creation)
        public string FirstName { get; set; } // Customer's First Name

        [MaxLength(125)] // String Object Maximum Character Length (used on database table creation)
        public string Address { get; set; }  // Customer's Addess
    }
}
