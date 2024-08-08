using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class SaveJob
    {
        public int SaveJobId { get; set; }

        [Comment("Mã người tìm việc")]
        public int? CandidateId { get; set; }

        [Comment("Mã người tuyển dụng")]
        public int? RecruitJobId { get; set; }

        [Comment("Trạng thái")]
        public bool? Status { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual RecruitJob RecruitJob { get; set; }
    }
}