using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class SignUpNewsletter
    {
        [Key]
        public int RegisterID { get; set; }

        [Comment("Email nhận")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Comment("Tên người nhận")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Comment("Có nhận tin tức hay không?")]
        public bool CheckNew { get; set; }

        [Comment("Có nhận tin đăng tuyển dụng hay không?")]
        public bool CheckPost { get; set; }

        public int? ProfessionId { get; set; }
    }
}