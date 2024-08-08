using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class CityRepository : RecruitmentRepository<City>, ICityRepository
    {
        public CityRepository(RecruitmentDbContext context) : base(context)
        {
        }
    }
}