using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Recruitment.API.DTOs;
using Recruitment.API.Helpers;
using Recruitment.API.Models;

namespace Recruitment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                IOptions<AppSettings> appSettings, IMapper mapper)
        {
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var user = await userManager.FindByEmailAsync(userLoginDTO.Email);

            var result = await signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);
            if (result.Succeeded)
            {
                 var userInfo = mapper.Map<UserInfoDTO>(user);

                return Ok(new
                {
                    token = await GenerateJwtToken(user),
                    userInfo
                });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var user = await userManager.FindByEmailAsync(userRegisterDTO.Email);
            if (user != null)
            {
                return BadRequest(new { message = "Email này đã có trong hệ thống!" });
            }

            var result = await CreateUser(userRegisterDTO);

            if (result.Succeeded)
            {
                return Ok(new { message = "Đăng ký thành công!" });
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJwtToken(ApplicationUser applicationUser)
        {
            // generate token that is valid for 1 days

            var claims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
                new Claim(ClaimTypes.Name, applicationUser.UserName.ToString())};

            var roles = await userManager.GetRolesAsync(applicationUser);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private async Task<IdentityResult> CreateUser(UserRegisterDTO userRegisterDTO)
        {
            IdentityResult result = null;
            if (userRegisterDTO.Type == Role.Candidate)
            {
                var candidateUser = mapper.Map<Candidate>(userRegisterDTO);
                result = await userManager.CreateAsync(candidateUser, userRegisterDTO.Password);
                await userManager.AddToRoleAsync(candidateUser, Role.Candidate);
            }
            else if (userRegisterDTO.Type == Role.Recruiter)
            {
                var recruitUser = mapper.Map<Recruit>(userRegisterDTO);
                result = await userManager.CreateAsync(recruitUser, userRegisterDTO.Password);
                await userManager.AddToRoleAsync(recruitUser, Role.Recruiter);
            }
            else
            {
                var applicationUser = mapper.Map<ApplicationUser>(userRegisterDTO);
                result = await userManager.CreateAsync(applicationUser, userRegisterDTO.Password);

            }

            return result;
        }
    }
}