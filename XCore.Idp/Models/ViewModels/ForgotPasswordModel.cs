using System.ComponentModel.DataAnnotations;

namespace XCore.Idp.Models.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
