using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.API.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public double? Min {get;set;}
        public double? Max { get; set; }

        [MaxLength(255)]
        public string Show { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
    }
}