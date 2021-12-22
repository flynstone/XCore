using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.Categories
{
    public class CategoryForUpdateDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
