using System.ComponentModel.DataAnnotations;

namespace Recruitment.API.DTOs
{
    public class UserLoginDTO
    {
        public string Type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}