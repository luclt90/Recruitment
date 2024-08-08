using Microsoft.AspNetCore.Identity;

namespace Recruitment.API.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}