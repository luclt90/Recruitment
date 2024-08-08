namespace Recruitment.API.Models
{
    public class SaveCandidate
    {
        public int SaveCandidateId { get; set; }
        public int? CandidateId { get; set; }
        public int? RecruitId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Recruit Recruit { get; set; }
    }
}