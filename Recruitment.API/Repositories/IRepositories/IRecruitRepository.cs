using System.Threading.Tasks;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public interface IRecruitRepository: IRecruitmentRepository<Recruit>
    {
         Task<int> UpdateProfile(Recruit recruit, int type);
    }
}