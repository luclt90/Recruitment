using System.Collections.Generic;
using System.Threading.Tasks;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public interface IDistrictRepository : IRecruitmentRepository<District>
    {
        Task<List<District>> GetDistrictsByCityId(int cityId);
    }
}