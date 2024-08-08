using System.Collections.Generic;
using System.Threading.Tasks;
using Recruitment.API.Helpers;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public interface IRecruitJobRepository : IRecruitmentRepository<RecruitJob>
    {
        Task<PagedList<RecruitJob>> GetJobsPostedByRecruitId(RecruitJobParams recruitJobParams);
    }
}