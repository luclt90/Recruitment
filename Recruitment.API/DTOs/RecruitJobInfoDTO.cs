using System;

namespace Recruitment.API.DTOs
{
    //For display in homepage
    public class RecruitJobInfoDTO
    {
        public int RecruitJobId { get; set; }
        public string Title { get; set; }
        public int? RecruitId { get; set; }
        public string WorkPlace { get; set; }
        public int? WorkTypeId { get; set; }
        //
        public virtual RecruitInfoDTO Recruit { get; set; }
        public virtual WorkTypeDTO WorkType { get; set; }

    }
}