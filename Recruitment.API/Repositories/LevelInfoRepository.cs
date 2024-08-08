using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class LevelInfoRepository : RecruitmentRepository<LevelInfo>, ILevelInfoRepository
    {
        public LevelInfoRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}