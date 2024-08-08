using System;

namespace Recruitment.API.DTOs
{
    public class RecruitDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string About { get; set; }
        public DateTime? FoundedYear { get; set; }
        public int? CompanySizeId { get; set; }
        public int? ProfessionId { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }

        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }

        public virtual ProfessionDTO Profession { get; set; }
        public virtual CompanySizeDTO CompanySize { get; set; }
        public virtual CityDTO City { get; set; }
        public virtual DistrictDTO District { get; set; }
        public virtual WardDTO Ward { get; set; }

    }
}