using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recruitment.API.DTOs;
using Recruitment.API.Repositories;

namespace Recruitment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly ICityRepository cityRepo;
        private readonly IMapper mapper;
        private readonly IDistrictRepository districtRepo;
        private readonly IWardRepository wardRepo;
        private readonly ICompanySizeRepository companySizeRepo;
        private readonly IExperienceRepository experienceRepo;
        private readonly ILevelInfoRepository levelInfoRepo;
        private readonly ISalaryRepository salaryRepo;
        private readonly IWorkTypeRepository workTypeRepo;

        public CommonController(ICompanySizeRepository companySizeRepo, ICityRepository cityRepo, IDistrictRepository districtRepo,
                                IWardRepository wardRepo, IExperienceRepository experienceRepo, ILevelInfoRepository levelInfoRepo,
                                ISalaryRepository salaryRepo, IWorkTypeRepository workTypeRepo, IMapper mapper)
        {
            this.workTypeRepo = workTypeRepo;
            this.salaryRepo = salaryRepo;
            this.levelInfoRepo = levelInfoRepo;
            this.experienceRepo = experienceRepo;
            this.companySizeRepo = companySizeRepo;
            this.wardRepo = wardRepo;
            this.districtRepo = districtRepo;
            this.cityRepo = cityRepo;
            this.mapper = mapper;
        }

        [HttpGet("company-sizes")]
        public async Task<IActionResult> GetCompanySizes()
        {
            var companySizes = await companySizeRepo.SelectAll();
            var result = new List<CompanySizeDTO>();
            foreach (var companySize in companySizes)
            {
                var companySizeDTO = mapper.Map<CompanySizeDTO>(companySize);
                result.Add(companySizeDTO);
            }

            return Ok(result);
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await cityRepo.SelectAll();
            var result = new List<CityDTO>();
            foreach (var city in cities)
            {
                var cityDTO = mapper.Map<CityDTO>(city);
                result.Add(cityDTO);
            }

            return Ok(result);
        }

        [HttpGet("districts/{cityId}")]
        public async Task<IActionResult> GetDistrictsByCityId(int cityId)
        {
            var result = new List<DistrictDTO>();
            var districts = await districtRepo.GetDistrictsByCityId(cityId);
            foreach (var district in districts)
            {
                var districtDTO = mapper.Map<DistrictDTO>(district);
                result.Add(districtDTO);
            }

            return Ok(result);
        }

        [HttpGet("wards/{districtId}")]
        public async Task<IActionResult> GetWardsByDistrictId(int districtId)
        {
            var result = new List<WardDTO>();
            var wards = await wardRepo.GetWardsByDistrictId(districtId);
            foreach (var ward in wards)
            {
                var wardDTO = mapper.Map<WardDTO>(ward);
                result.Add(wardDTO);
            }

            return Ok(result);
        }

        [HttpGet("experiences")]
        public async Task<IActionResult> GetExperiences()
        {
            var experiences = await experienceRepo.SelectAll();
            var result = new List<ExperienceDTO>();
            foreach (var experience in experiences)
            {
                var experienceDTO = mapper.Map<ExperienceDTO>(experience);
                result.Add(experienceDTO);
            }

            return Ok(result);
        }

        [HttpGet("level-info")]
        public async Task<IActionResult> GetLevelInfos()
        {
            var levelInfos = await levelInfoRepo.SelectAll();
            var result = new List<LevelInfoDTO>();
            foreach (var levelInfo in levelInfos)
            {
                var elevelInfoDTO = mapper.Map<LevelInfoDTO>(levelInfo);
                result.Add(elevelInfoDTO);
            }

            return Ok(result);
        }

        [HttpGet("salaries")]
        public async Task<IActionResult> GetSalaries()
        {
            var salaries = await salaryRepo.SelectAll();
            var result = new List<SalaryDTO>();
            foreach (var salary in salaries)
            {
                var salaryDTO = mapper.Map<SalaryDTO>(salary);
                result.Add(salaryDTO);
            }

            return Ok(result);
        }

        [HttpGet("work-type")]
        public async Task<IActionResult> GetWorkTypes()
        {
            var workTypes = await workTypeRepo.SelectAll();
            var result = new List<WorkTypeDTO>();
            foreach (var workType in workTypes)
            {
                var workTypeDTO = mapper.Map<WorkTypeDTO>(workType);
                result.Add(workTypeDTO);
            }

            return Ok(result);
        }
    }
}