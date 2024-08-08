using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class ExperienceRepository : RecruitmentRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}