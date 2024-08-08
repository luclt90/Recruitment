using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        [Comment("Tên quận/huyện")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Comment("Mã tỉnh/thành phố")]
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Ward> Wards { get; set; } = new HashSet<Ward>();
        public virtual ICollection<Recruit> Recruits { get; set; } = new HashSet<Recruit>();
        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
        public virtual ICollection<RecruitJob> RecruitJobs { get; set; } = new HashSet<RecruitJob>();
        
    }
}