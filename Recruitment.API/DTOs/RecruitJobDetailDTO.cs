using System;

namespace Recruitment.API.DTOs
{
    //Display in List recruit jobs
    public class RecruitJobDetailDTO
    {
        public int RecruitJobId { get; set; }
        public string Title { get; set; }
        public int? RecruitId { get; set; }
        public string WorkPlace { get; set; }
        public int? WorkTypeId { get; set; }

        public DateTime? PostDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        //
        public virtual RecruitInfoDTO Recruit { get; set; }
        public virtual WorkTypeDTO WorkType { get; set; }

        //add class show
        public string ClassWorkType { get; set; }
        public string GenderName { get; set; }
        public int CountDays { get; set; }
        public int AppliedCount { get; set; }

        public string StateShow { get; set; }
        public string NameType { get; set; }
        public string ExpirationDateString { get; set; }
    }
}