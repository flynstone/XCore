using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.Customers
{
    public class CustomerForUpdateDto
    {
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
