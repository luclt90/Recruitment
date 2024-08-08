using System;

namespace Recruitment.API.Models
{
    public class UserInfoDTO
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}