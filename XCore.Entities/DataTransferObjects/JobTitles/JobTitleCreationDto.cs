using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.JobTitles
{
    public class JobTitleCreationDto
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
