using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.Models.Rentals
{
    public class Category
    {
        // Primary Key
        public int CategoryId { get; set; }

        [MaxLength(50)] // String Object Maximum Length (for database)
        public string Description { get; set; } // Category name
    }
}
