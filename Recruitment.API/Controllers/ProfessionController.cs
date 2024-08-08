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
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionRepository professionRepo;
        private readonly IMapper mapper;

        public ProfessionController(IProfessionRepository professionRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.professionRepo = professionRepo;
        }

        [HttpGet("professions")]
        public async Task<IActionResult> GetAllProfessions()
        {
            var professions = await professionRepo.SelectAll();
            var result = new List<ProfessionDTO>();
            foreach (var profession in professions)
            {
                var professionDTO = mapper.Map<ProfessionDTO>(profession);
                result.Add(professionDTO);
            }

            return Ok(result);
        }
    }
}