using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruitment.API.Data;
using Recruitment.API.DTOs;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class DistrictRepository : RecruitmentRepository<District>, IDistrictRepository
    {
        public DistrictRepository(RecruitmentDbContext context) : base(context)
        {
        }

        public async Task<List<District>> GetDistrictsByCityId(int cityId)
        {
            return await this.All.Where(x => x.CityId == cityId).ToListAsync();
        }
    }
}