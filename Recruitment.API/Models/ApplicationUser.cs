using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Recruitment.API.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}