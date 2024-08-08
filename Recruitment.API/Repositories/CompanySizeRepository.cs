using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class CompanySizeRepository : RecruitmentRepository<CompanySize>, ICompanySizeRepository
    {
        public CompanySizeRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}