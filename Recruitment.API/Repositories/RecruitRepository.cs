using System;
using System.Threading.Tasks;
using Recruitment.API.Data;
using Recruitment.API.Models;

namespace Recruitment.API.Repositories
{
    public class RecruitRepository : RecruitmentRepository<Recruit>, IRecruitRepository
    {
        public RecruitRepository(RecruitmentDbContext context) : base(context)
        {
        }

        public async Task<int> UpdateProfile(Recruit recruit, int type)
        {
            try
            {
                var recruitEF = await this.SelectById(recruit.Id);
                //type = 1: update information, type = 2: update contact
                if (type == 1)
                {
                    recruitEF.CoverImage = recruit.CoverImage;
                    recruitEF.Avatar = recruit.Avatar;
                    recruitEF.CompanyName = recruit.CompanyName;
                    recruitEF.Logo = recruit.Logo;
                    recruitEF.FoundedYear = recruit.FoundedYear;
                    recruitEF.CompanySizeId = recruit.CompanySizeId;
                    recruitEF.ProfessionId = recruit.ProfessionId;
                    recruitEF.About = recruit.About;
                }
                else
                {
                    //Social
                    recruitEF.Facebook = recruit.Facebook;
                    recruitEF.Google = recruitEF.Google;
                    recruitEF.Twitter = recruitEF.Twitter;
                    recruitEF.Linkedin = recruitEF.Linkedin;
                    //Contact
                    recruitEF.Phone = recruit.Phone;
                    recruitEF.Email = recruit.Email;
                    recruitEF.Website = recruit.Website;
                    recruitEF.CityId = recruit.CityId;
                    recruitEF.DistrictId = recruit.DistrictId;
                    recruitEF.WardId = recruit.WardId;
                    recruitEF.Address = recruit.Address;
                }

                await this.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}