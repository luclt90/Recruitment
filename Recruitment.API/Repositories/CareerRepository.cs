using Microsoft.EntityFrameworkCore;
using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class CareerRepository : RecruitmentRepository<Career>, ICareerRepository
    {
        public CareerRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}