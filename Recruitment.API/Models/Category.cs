using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Recruitment.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Comment("Tên ngành")]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<New> News { get; set; } = new HashSet<New>();
    }
}