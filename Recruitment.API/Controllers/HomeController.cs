using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recruitment.API.DTOs;
using Recruitment.API.Repositories;
using System.Linq;
using System;
using static Recruitment.API.Helpers.Enum;

namespace Recruitment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICareerRepository careerRepo;
        private readonly IMapper mapper;
        private readonly IRecruitJobRepository recruitJobRepo;
        private readonly ICandidateRepository candidateRepo;
        private readonly IRecruitRepository recruitRepo;

        public HomeController(ICareerRepository careerRepo, IRecruitJobRepository recruitJobRepo,
         ICandidateRepository candidateRepo, IRecruitRepository recruitRepo, IMapper mapper)
        {
            this.recruitRepo = recruitRepo;
            this.candidateRepo = candidateRepo;
            this.recruitJobRepo = recruitJobRepo;
            this.mapper = mapper;
            this.careerRepo = careerRepo;
        }

        [HttpGet("careers")]
        public async Task<IActionResult> GetAllCareers()
        {
            var careers = await careerRepo.SelectAll();
            var result = new List<CareerDTO>();
            foreach (var career in careers)
            {
                var carrerDTO = mapper.Map<CareerDTO>(career);
                carrerDTO.CountJob = recruitJobRepo.All.Where(x => x.Profession.CareerId == career.CareerId && x.ExpirationDate >= DateTime.Now &&
                                     x.Status != (int?)EnumStatusJob.Inactive).Count();
                result.Add(carrerDTO);
            }

            return Ok(result);
        }

        [HttpGet("candidate/count")]
        public IActionResult CandidateCount()
        {
            //.Where(x => x.Status == (int?)StatusCandidate.Active)
            var count = candidateRepo.All.Count();

            return Ok(count);
        }

        [HttpGet("recruit/count")]
        public IActionResult RecruitCount()
        {
            //.Where(x => x.Status == (int?)StatusCandidate.Active)
            var count = recruitRepo.All.Count();

            return Ok(count);
        }

        [HttpGet("recruit-job/count")]
        public IActionResult RecruitJobCount()
        {
            //.Where(x => x.Status == (int?)StatusCandidate.Active)
            var count = recruitJobRepo.All.Count();

            return Ok(count);
        }
    }
}