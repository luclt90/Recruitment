using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class RecruitJob
    {
        public int RecruitJobId { get; set; }

        [Comment("Tiêu đề")]
        [MaxLength(500)]
        public string Title { get; set; }

        [Comment("Vị trí tuyển dụng")]
        [MaxLength(255)]
        public string Position { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Comment("Số lượng")]
        public int? Amount { get; set; }

        [Comment("Mô tả công việc")]
        [Column(TypeName = "ntext")]
        public string Describe { get; set; }

        [Comment("Mô tả yêu cầu")]
        [Column(TypeName = "ntext")]
        public string Require { get; set; }

        [Comment("Mô tả lợi ích")]
        [Column(TypeName = "ntext")]
        public string Benefit { get; set; }

        [Comment("Nơi làm việc")]
        [Column(TypeName = "ntext")]
        public string WorkPlace { get; set; }

        [Comment("Ngày đăng")]
        [Column(TypeName = "datetime")]
        public DateTime? PostDate { get; set; }

        [Comment("Ngày hết hạn")]
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

        [MaxLength(255)]
        public string EmailContact { get; set; }

        [MaxLength(255)]
        public string NameContact { get; set; }

        [MaxLength(20)]
        public string PhoneContact { get; set; }
        public int? Gender { get; set; }

        [Comment("Trạng thái")]
        public int? Status { get; set; }

        [Comment("Thể loại")]
        public int? Type { get; set; }
        public int? SalaryId { get; set; }
        public int? ExperienceId { get; set; }
        public int? RecruitId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? ProfessionId { get; set; }

        [Comment("Mã trình độ")]
        public int? LevelInfoId { get; set; }

        [Comment("Mã thể loại làm việc")]
        public int? WorkTypeId { get; set; }

        [Comment("Số lượng xem tin")]
        public int? Count { get; set; }

        public virtual Salary Salary { get; set; }
        public virtual Experience Experience { get; set; }
        public virtual Recruit Recruit { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual LevelInfo LevelInfo { get; set; }
        public virtual WorkType WorkType { get; set; }

        public virtual ICollection<CandidatePostResume> CandidatePostResumes { get; set; } = new HashSet<CandidatePostResume>();
    }
}