using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class CandidatePostResumeRepository : RecruitmentRepository<CandidatePostResume>, ICandidatePostResumeRepository
    {
        public CandidatePostResumeRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}