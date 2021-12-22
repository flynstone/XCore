using System.ComponentModel.DataAnnotations;


namespace XCore.Entities.DataTransferObjects.Crews
{
    public class CrewCreationDto
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
