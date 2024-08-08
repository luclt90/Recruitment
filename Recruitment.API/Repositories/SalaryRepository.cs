using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class SalaryRepository : RecruitmentRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}