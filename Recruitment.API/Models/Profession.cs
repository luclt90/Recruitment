using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }

        [Comment("Tên công việc")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Comment("Mã ngành")]
        public int? CareerId { get; set; }

        public virtual Career Career { get; set; }
        public virtual ICollection<Recruit> Recruits { get; set; } = new HashSet<Recruit>();
         public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
    }
}