using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.API.Models
{
    public class CompanySize
    {
        public int CompanySizeId { get; set; }
        public int? Min {get;set;}
        public int? Max { get; set; }

        [MaxLength(255)]
        public string Show { get; set; }

        public virtual ICollection<Recruit> Recruits { get; set; } = new HashSet<Recruit>();
    }
}