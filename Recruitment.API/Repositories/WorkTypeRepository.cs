using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class WorkTypeRepository : RecruitmentRepository<WorkType>, IWorkTypeRepository
    {
        public WorkTypeRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}