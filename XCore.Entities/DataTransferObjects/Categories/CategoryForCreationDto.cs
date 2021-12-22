using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.Categories
{
    public class CategoryForCreationDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
