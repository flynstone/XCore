using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCore.Entities.Models.Rentals
{
    public class Media
    {
        // Primary Key
        public int MediaId { get; set; }

        [MaxLength(100)] // String Object Maximum Length (for database)
        public string ItemTitle { get; set; } // Media Name

        [ForeignKey("Category")] 
        public int CategoryId { get; set; } // Category's Foreign Key
        public virtual Category ItemCategory { get; set; } // Category's Navigation Property
    }
}
