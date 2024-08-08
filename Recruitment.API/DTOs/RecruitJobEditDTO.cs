using System;

namespace Recruitment.API.DTOs
{
    public class RecruitJobEditDTO
    {
        public int RecruitJobId { get; set; }
        public string Title { get; set; }
        public int? RecruitId { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public int? Amount { get; set; }
        public int? ProfessionId { get; set; }
        public int? LevelInfoId { get; set; }
        public string Benefit { get; set; }
        public string Describe { get; set; }
        public string Require { get; set; }
        public int? WorkTypeId { get; set; }
        public int? SalaryId { get; set; }
        public string WorkPlace { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Contact { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string NameContact { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public int? ExperienceId { get; set; }
        public int? Gender { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? Count { get; set; }

        //
        public virtual RecruitDTO Recruit { get; set; }

        //
        public string ClassWorkType { get; set; }
    }
}