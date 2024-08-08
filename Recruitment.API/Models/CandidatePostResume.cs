using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class CandidatePostResume
    {
        public int CandidatePostResumeId { get; set; }
        public int? CandidateId { get; set; }
        public int? RecruitJobId { get; set; }

        [Comment("Ngày ứng tuyển")]
        [Column(TypeName = "datetime")]
        public DateTime? PostDate { get; set; }
        public bool? Status { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Comment("Link CV")]
        [Column(TypeName = "ntext")]
        public string PathFileCV { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual RecruitJob RecruitJob { get; set; }
    }
}