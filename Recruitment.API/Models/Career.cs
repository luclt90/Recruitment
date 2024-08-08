using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.API.Models
{
    public class Career
    {
        public int CareerId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Profession> Professions { get; set; }= new HashSet<Profession>();
    }
}