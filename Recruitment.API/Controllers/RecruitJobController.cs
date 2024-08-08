using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recruitment.API.DTOs;
using Recruitment.API.Models;
using Recruitment.API.Repositories;
using static Recruitment.API.Helpers.Enum;

namespace Recruitment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitJobController : ControllerBase
    {
        private readonly IRecruitJobRepository recruitJobRepo;
        private readonly IMapper mapper;

        public RecruitJobController(IRecruitJobRepository recruitJobRepo, IMapper mapper)
        {
            this.recruitJobRepo = recruitJobRepo;
            this.mapper = mapper;
        }

        [HttpGet("all/{type:int?}")]
        public async Task<IActionResult> GetListRecruitJobsByType([FromQuery] int? type)
        {
            var recruitJobs = await recruitJobRepo.All.Where(x => x.Type == type && x.ExpirationDate >= DateTime.Now && x.Status != (int?)EnumStatusJob.Inactive)
                                .ToListAsync();
            if (recruitJobs.Count == 0)
                recruitJobs = await recruitJobRepo.All.Where(x => x.ExpirationDate >= DateTime.Now && x.Status != (int?)EnumStatusJob.Inactive)
                                .ToListAsync();
            var listDTO = new List<RecruitJobInfoDTO>();
            foreach (var recruitJob in recruitJobs)
            {
                listDTO.Add(mapper.Map<RecruitJobInfoDTO>(recruitJob));
            }

            return Ok(listDTO);
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            //.Where(x => x.Status == (int?)StatusCandidate.Active)
            var count = recruitJobRepo.All.Count();

            return Ok(count);
        }


        [HttpPost("add")]
        public IActionResult PostANewJob([FromBody] RecruitJobEditDTO recruitJobEditDTO)
        {
            recruitJobEditDTO.Count = 0;
            recruitJobEditDTO.PostDate = DateTime.Now;
            recruitJobEditDTO.Status = (int)EnumStatusJob.Approvaling;
            recruitJobEditDTO.Type = (int?)EnumTypeJob.Normal;
            
            var resultCode = recruitJobRepo.Insert(mapper.Map<RecruitJob>(recruitJobEditDTO));

            if (resultCode != null)
            {
                return Ok(new { message = "Thêm mới công việc thành công" });
            }

            return BadRequest(new { message = "Có lỗi xảy ra khi thêm mới công việc" });
        }

    }
}