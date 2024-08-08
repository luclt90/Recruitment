using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Comment("Tên tỉnh/thành phố")]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; } = new HashSet<District>();
        public virtual ICollection<Recruit> Recruits { get; set; } = new HashSet<Recruit>();
        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
    }
}