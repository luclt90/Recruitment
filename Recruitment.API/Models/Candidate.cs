using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Candidate : ApplicationUser
    {
        [MaxLength(255)]        
        public string FullName { get; set; }

        [Comment("Ảnh đại diện")]
        [MaxLength(255)]
        public string Avatar { get; set; }

        [Comment("Giới tính")]
        public int? Sex { get; set; }

        [Comment("Giới thiệu bản thân")]
        [Column(TypeName = "ntext")]
        public string About { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // [MaxLength(255)]
        // public string Email { get; set; }

        [Comment("Vị trí")]
        [MaxLength(255)]
        public string Position { get; set; }

        [Comment("Mô tả kinh nghiệm")]
        [Column(TypeName = "ntext")]
        public string ExperienceInfo { get; set; }

        [Column(TypeName = "ntext")]
        public string Speciality { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? PostDate { get; set; }
        public int? Status { get; set; }
        public int? Age { get; set; }

        [Comment("Ngày đăng ký")]
        [Column(TypeName = "datetime")]
        public DateTime? RegisterDate { get; set; }

        [MaxLength(500)]
        public string Facebook { get; set; }

        [MaxLength(500)]
        public string Google { get; set; }

        public int? ProfessionId { get; set; }
        public int? LevelInfoId { get; set; }
        public int? ExperienceId { get; set; }
        public int? WorkTypeId { get; set; }
        public int? SalaryId { get; set; }

        public int? WardId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }

        [MaxLength(1000)]
        public string PathCV { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }

        [Comment("Mô tả CV")]
        [Column(TypeName = "ntext")]
        public string DescribeCV { get; set; }
        public virtual City City { get; set; }        
        public virtual District District { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual LevelInfo LevelInfo { get; set; }
        public virtual Experience Experience { get; set; }
        public virtual WorkType WorkType { get; set; }
        public virtual Salary Salary { get; set; }

        public virtual ICollection<SaveCandidate> SaveCandidates { get; set; } = new HashSet<SaveCandidate>();
        public virtual ICollection<SaveJob> SaveJobs { get; set; } = new HashSet<SaveJob>();
        public virtual ICollection<CandidatePostResume> CandidatePostResume { get; set; } = new HashSet<CandidatePostResume>();

    }
}