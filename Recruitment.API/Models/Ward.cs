using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Ward
    {
        public int WardId { get; set; }

        [Comment("Tên xã/phường")]
        [MaxLength(255)]
        public string Name { get; set; }
        
        public int? DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Recruit> Recruits { get; set; } = new HashSet<Recruit>();
        public virtual ICollection<Candidate> Candidates { get; set; } = new HashSet<Candidate>();
    }
}