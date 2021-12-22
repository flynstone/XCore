using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.Backups
{
    public class BackupCreationDto
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
