using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recruitment.API.DTOs;
using Recruitment.API.Models;
using Recruitment.API.Repositories;
using System.Collections.Generic;
using Recruitment.API.Helpers;
using Recruitment.API.Helpers.Extensions;

namespace Recruitment.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RecruitController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRecruitRepository recruitRepo;
        private readonly IMapper mapper;
        private readonly IRecruitJobRepository recruitJobRepository;
        private readonly ICandidatePostResumeRepository candidatePostResumeRepository;
        public RecruitController(IRecruitRepository recruitRepo, IRecruitJobRepository recruitJobRepository,
        ICandidatePostResumeRepository candidatePostResumeRepository, IMapper mapper)
        {
            this.candidatePostResumeRepository = candidatePostResumeRepository;
            this.recruitJobRepository = recruitJobRepository;
            this.mapper = mapper;
            this.recruitRepo = recruitRepo;
        }

        [Authorize(Roles = Role.Recruiter)]
        [HttpGet("recruit-info/{recruitId}")]
        public async Task<IActionResult> GetDetailRecruitById(int recruitId)
        {
            var recruit = await recruitRepo.SelectById(recruitId);
            var recruitDTO = mapper.Map<RecruitDTO>(recruit);

            return Ok(recruitDTO);
        }

        [Authorize(Roles = Role.Recruiter)]
        [HttpPut("update/info")]
        public async Task<IActionResult> UpdateRecruitInfo(RecruitDTO recruitDTO)
        {
            var resultCode = await recruitRepo.UpdateProfile(mapper.Map<Recruit>(recruitDTO), 1);

            if (resultCode == 1)
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }

            return BadRequest(new { message = "Có lỗi xảy ra khi cập nhật thông tin" });
        }

        [Authorize(Roles = Role.Recruiter)]
        [HttpPut("update/contact")]
        public async Task<IActionResult> UpdateRecruitContact(RecruitDTO recruitDTO)
        {
            if (HasExistedEmail(recruitDTO.Id, recruitDTO.Email))
            {
                return BadRequest(new { message = "Email đã được sử dụng" });
            }

            if (HasExistedPhone(recruitDTO.Id, recruitDTO.Phone))
            {
                return BadRequest(new { message = "Số điện thoại đã được sử dụng" });
            }

            var resultCode = await recruitRepo.UpdateProfile(mapper.Map<Recruit>(recruitDTO), 2);

            if (resultCode == 1)
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }

            return BadRequest(new { message = "Có lỗi xảy ra khi cập nhật thông tin" });
        }

        [Authorize(Roles = Role.Recruiter)]
        [HttpGet("jobs-posted")]
        public async Task<IActionResult> FetchJobsPosted([FromQuery] RecruitJobParams recruitJobParams)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (int.TryParse(userId, out int id))
            {
                // var recruitInfo = await recruitRepo.SelectById(id);
                recruitJobParams.recruitId = id;

                List<RecruitJobDetailDTO> result = new List<RecruitJobDetailDTO>();
                var recruitJobs = await recruitJobRepository.GetJobsPostedByRecruitId(recruitJobParams);
                foreach (var recruitJob in recruitJobs)
                {
                    var recruitJobDetailDTO = mapper.Map<RecruitJobDetailDTO>(recruitJob);

                    var countApplied = candidatePostResumeRepository.All.Where(x => x.RecruitJobId == recruitJob.RecruitJobId).ToList();
                    recruitJobDetailDTO.AppliedCount = countApplied.Count;

                    result.Add(recruitJobDetailDTO);
                }

                Response.AddPagination(recruitJobs.CurrentPage, recruitJobs.PageSize,
                 recruitJobs.TotalCount, recruitJobs.TotalPages);

                return Ok(result);

            }

            return Unauthorized();
        }

        #region private methods

        private bool HasExistedPhone(int id, string phone)
        {
            var hasExisted = recruitRepo.All.Any(recruit => recruit.Id != id && recruit.Phone == phone);
            return hasExisted;
        }

        private bool HasExistedEmail(int id, string email)
        {
            var hasExisted = recruitRepo.All.Any(recruit => recruit.Id != id && recruit.Email == email);
            return hasExisted;
        }

        #endregion
    }
}