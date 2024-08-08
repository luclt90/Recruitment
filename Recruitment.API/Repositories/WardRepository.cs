using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class WardRepository : RecruitmentRepository<Ward>, IWardRepository
    {
        public WardRepository(RecruitmentDbContext context) : base(context)
        {
        }

        public async Task<List<Ward>> GetWardsByDistrictId(int districtId)
        {
            return await this.All.Where(x => x.DistrictId == districtId).ToListAsync();
        }
    }
}