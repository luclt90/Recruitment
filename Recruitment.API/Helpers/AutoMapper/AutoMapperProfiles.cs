using AutoMapper;
using Recruitment.API.DTOs;
using Recruitment.API.Models;
using static Recruitment.API.Helpers.Enum;

namespace Recruitment.API.Helpers.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDTO, ApplicationUser>().ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(user => user.Phone));
            CreateMap<UserRegisterDTO, Candidate>();
            CreateMap<UserRegisterDTO, Recruit>();
            CreateMap<ApplicationUser, UserInfoDTO>();
            CreateMap<Profession, ProfessionDTO>().ReverseMap();
            CreateMap<CareerDTO, Career>();
            CreateMap<Recruit, RecruitDTO>().ReverseMap();
            CreateMap<Recruit, RecruitInfoDTO>();
            CreateMap<RecruitJob, RecruitJobInfoDTO>();
            CreateMap<RecruitJob, RecruitJobEditDTO>().ReverseMap();
            CreateMap<CompanySize, CompanySizeDTO>().ReverseMap();
            CreateMap<Experience, ExperienceDTO>().ReverseMap();
            CreateMap<LevelInfo, LevelInfoDTO>().ReverseMap();
            CreateMap<Salary, SalaryDTO>().ReverseMap();
            CreateMap<WorkType, WorkTypeDTO>().ReverseMap();
            CreateMap<Career, CareerDTO>().ForMember(dest => dest.Icon, opt =>
            {
                opt.MapFrom(src => GetIcon4Career(src.CareerId));
            });
            CreateMap<RecruitJob, RecruitJobDetailDTO>().ForMember(dest => dest.StateShow, opt =>
            {
                opt.MapFrom(src => ConvertStatusToString(src.Status));
            });

            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<District, DistrictDTO>().ReverseMap();
            CreateMap<Ward, WardDTO>().ReverseMap();
        }

        private string ConvertStatusToString(int? status)
        {
            string stateShow = string.Empty;
            switch (status)
            {
                case (int)EnumStatusJob.Active:
                    stateShow = "Hoạt động";
                    break;
                case (int)EnumStatusJob.Approvaling:
                    stateShow = "Chờ xét duyệt";
                    break;
                default:
                    stateShow = "Ngừng hoạt động";
                    break;
            }

            return stateShow;
        }

        private string GetIcon4Career(int careerId)
        {
            switch (careerId)
            {
                case (int)EnumCareer.BanHangTiepThi:
                    return "la la-tag";
                case (int)EnumCareer.HangTieuDung:
                    return "la la-cart-plus";
                case (int)EnumCareer.KyThuat:
                    return "la la-gears";
                case (int)EnumCareer.DichVu:
                    return "la la-globe";
                case (int)EnumCareer.MayTinhIT:
                    return "la la-desktop";
                case (int)EnumCareer.SucKhoe:
                    return "la la-user-md";
                case (int)EnumCareer.SanXuat:
                    return "la la-industry";
                case (int)EnumCareer.HanhChinhNhanSu:
                    return "la la-users";
                case (int)EnumCareer.KeToanTaiChinh:
                    return "la la-money";
                case (int)EnumCareer.TruyenThongMedia:
                    return "la la-bullhorn";
                case (int)EnumCareer.XayDung:
                    return "la la-building";
                case (int)EnumCareer.GiaoDucDaoTao:
                    return "la la-graduation-cap";
                case (int)EnumCareer.KhoaHoc:
                    return "la la-flask";
                case (int)EnumCareer.KhachSanDuLich:
                    return "la la-globe";
                default:
                    return "la la-bars";
            }
        }
    }
}