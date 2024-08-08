using System;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.API.DTOs
{
    public class UserRegisterDTO
    {
        public string Type { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime? RegisterDate { get; set; } = DateTime.UtcNow;
    }
}