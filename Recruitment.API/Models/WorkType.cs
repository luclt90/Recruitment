using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class WorkType
    {
        public int WorkTypeId { get; set; }
        
        [Comment("Tên loại hình làm việc")]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
    }
}