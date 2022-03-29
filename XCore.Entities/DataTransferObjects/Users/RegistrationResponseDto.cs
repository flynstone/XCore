using System.Collections.Generic;

namespace XCore.Entities.DataTransferObjects.Users
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
