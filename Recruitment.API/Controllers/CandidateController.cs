using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruitment.API.Repositories;
using System.Linq;
using static Recruitment.API.Helpers.Enum;

namespace Recruitment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository repo;
        public CandidateController(ICandidateRepository repo)
        {
            this.repo = repo;
        }

        
        [HttpGet("count")]
        public IActionResult Count()
        {
            //.Where(x => x.Status == (int?)StatusCandidate.Active)
            var count =  repo.All.Count();
            
            return Ok(count);
        }
        
    }
}