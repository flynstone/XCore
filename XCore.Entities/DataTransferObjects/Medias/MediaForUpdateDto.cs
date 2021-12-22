using System.ComponentModel.DataAnnotations;

namespace XCore.Entities.DataTransferObjects.Medias
{
    public class MediaForUpdateDto
    {
        [Required(ErrorMessage = "Item title is required")]
        public string ItemTitle { get; set; }

        public int CategoryId { get; set; }
    }
}
