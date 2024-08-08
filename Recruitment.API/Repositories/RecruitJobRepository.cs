using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruitment.API.Data;
using Recruitment.API.Helpers;
using Recruitment.API.Models;
using static Recruitment.API.Helpers.Enum;

namespace Recruitment.API.Repositories
{
    public class RecruitJobRepository : RecruitmentRepository<RecruitJob>, IRecruitJobRepository
    {
        public RecruitJobRepository(RecruitmentDbContext context) : base(context)
        {
        }

        public int CountJobWithType(int typeChoose)
        {
            var count = 0;
            //typeChoose = 1: count job posted
            //typeChoose = 2: count job approval
            //typeChoose = 3: count company
            //typeChoose = 5: count member

            switch (typeChoose)
            {
                case 1:
                    count = this.All.Where(x => x.Status != (int?)EnumStatusJob.Inactive).Count();
                    break;
                case 2:
                    count = this.All.Where(x => x.Status == (int?)EnumStatusJob.Active).Count();
                    break;
                case 3:
                    count = this.All.Where(x => x.Status == (int?)StatusRecruit.Active).Count();
                    break;
                case 5:
                    count = this.All.Where(x => x.PostDate == DateTime.Today).Count();
                    break;
                default:
                    count = this.All.Where(x => x.Status == (int?)StatusCandidate.Active).Count();
                    break;
            }

            return count;
        }

        public async Task<PagedList<RecruitJob>> GetJobsPostedByRecruitId(RecruitJobParams recruitJobParams)
        {
            var recruitJobs = All.OrderByDescending(x => x.PostDate).Where(x => x.RecruitId == recruitJobParams.recruitId && x.Type != (int?)EnumStatusJob.Inactive);

            return await PagedList<RecruitJob>.CreateAsync(recruitJobs, recruitJobParams.PageNumber, recruitJobParams.PageSize);
        }

    }
}