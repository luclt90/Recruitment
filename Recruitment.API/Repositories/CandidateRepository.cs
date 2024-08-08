using Microsoft.EntityFrameworkCore;
using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class CandidateRepository : RecruitmentRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}