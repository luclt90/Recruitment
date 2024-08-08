using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public double? Min {get;set;}
        public double? Max { get; set; }

        [Comment("Giá hiển thị")]
        [MaxLength(255)]
        public string Show { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
    }
}