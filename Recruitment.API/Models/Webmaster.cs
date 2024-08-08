using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Webmaster : ApplicationUser
    {
        [MaxLength(255)]
        public string FullName { get; set; }

        [Comment("Thể loại")]
        [Column(TypeName = "int")]
        public int? Type { get; set; }

        [Comment("Trạng thái")]
        [Column(TypeName = "int")]
        public int? Status { get; set; }

        [Comment("Giới tính")]
        [Column(TypeName = "int")]
        public int? Gender { get; set; }

        [Comment("Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        [Comment("Ngày bắt đầu")]
        [Column(TypeName = "datetime")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [Comment("Vị trí làm việc")]
        [Column(TypeName = "int")]
        public int? Position { get; set; }
        public virtual ICollection<New> News { get; set; } = new HashSet<New>();
    }
}