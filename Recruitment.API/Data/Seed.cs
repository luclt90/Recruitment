using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Recruitment.API.Models;

namespace Recruitment.API.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {


            var userCandidate = new Candidate()
            {
                Email = "candidate@gmail.com",
                UserName = "candidate",
                RegisterDate = System.DateTime.Now,
                Phone = "0933117456",
                PhoneNumber = "+84933117456",

            };

            var userRecruiter = new Recruit()
            {
                Email = "recruiter@gmail.com",
                UserName = "recruiter",
                RegisterDate = System.DateTime.Now,
                Phone = "0933117123",
                PhoneNumber = "+84933117123",

            };

            var userAdmin = new ApplicationUser()
            {
                Email = "admin@gmail.com",
                UserName = "admin",
                PhoneNumber = "+84933117123",

            };

            if (!userManager.Users.Any())
            {
                //Create roles
                var roles = new List<ApplicationRole>{
                    new ApplicationRole{Name = "Candidate"},
                    new ApplicationRole{Name = "Recruiter"},
                    new ApplicationRole{Name = "Admin"}
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
                //-----------------------------------------------------
                userManager.CreateAsync(userCandidate, "password").Wait();
                userManager.AddToRoleAsync(userCandidate, "Candidate").Wait();

                userManager.CreateAsync(userRecruiter, "password").Wait();
                userManager.AddToRoleAsync(userRecruiter, "Recruiter").Wait();

                userManager.CreateAsync(userAdmin, "password").Wait();
                userManager.AddToRoleAsync(userAdmin, "Admin").Wait();
            }

        }
    }
}