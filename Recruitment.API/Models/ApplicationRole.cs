using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Recruitment.API.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}