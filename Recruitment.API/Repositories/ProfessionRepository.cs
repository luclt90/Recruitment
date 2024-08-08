using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class ProfessionRepository : RecruitmentRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}