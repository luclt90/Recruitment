using System.Collections.Generic;
using System.Threading.Tasks;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public interface IWardRepository : IRecruitmentRepository<Ward>
    {
        Task<List<Ward>> GetWardsByDistrictId(int districtId);
    }
}