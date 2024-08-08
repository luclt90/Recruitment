using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Recruit : ApplicationUser
    {
        [MaxLength(255)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string CompanyName { get; set; }

        [Comment("Mô tả công ty")]
        [Column(TypeName = "ntext")]
        public string About { get; set; }

        [Comment("Logo công ty")]
        [MaxLength(255)]
        public string Logo { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Comment("Ngày đăng ký")]
        [Column(TypeName = "datetime")]
        public DateTime? RegisterDate { get; set; }

        [Comment("Trạng thái")]
        public int? Status { get; set; } = (int?)Helpers.Enum.StatusRecruit.Approvaling;

        [MaxLength(255)]
        public string Website { get; set; }
        [MaxLength(255)]
        public string Facebook { get; set; }
        [MaxLength(255)]
        public string Google { get; set; }
        [MaxLength(255)]
        public string Twitter { get; set; }
        [MaxLength(255)]
        public string Linkedin { get; set; }

        [Comment("Năm thành lập")]
        // [Column(TypeName = "datetime")]
        public int? FoundedYear { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? CompanySizeId { get; set; }
        public int? ProfessionId { get; set; }

        [Comment("Ảnh bìa")]
        [Column(TypeName = "ntext")]
        public string CoverImage { get; set; }

        [Comment("Ảnh đại diện")]
        [Column(TypeName = "ntext")]
        public string Avatar { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual CompanySize CompanySize { get; set; }
        public virtual Profession Profession { get; set; }

        public virtual ICollection<SaveCandidate> SaveCandidates { get; set; } = new HashSet<SaveCandidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();

    }
}