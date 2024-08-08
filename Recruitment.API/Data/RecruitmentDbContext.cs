using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recruitment.API.Models;

namespace Recruitment.API.Data
{
    public class RecruitmentDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int,
    IdentityUserClaim<int>, ApplicationUserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<New> News { get; set; }
        public DbSet<Webmaster> Webmasters { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<SaveJob> SaveJobs { get; set; }
        public DbSet<CandidatePostResume> CandidatePostResumes { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<LevelInfo> LevelInfos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<SaveCandidate> SaveCandidates { get; set; }
        public DbSet<Recruit> Recruits { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<RecruitJob> RecruitJobs { get; set; }

        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            builder.Entity<ApplicationRole>().ToTable("ApplicationRoles");

            builder.Entity<Candidate>().ToTable("Candidates");
            builder.Entity<Recruit>().ToTable("Recruits");
            builder.Entity<Webmaster>().ToTable("Webmasters");

            builder.Entity<ApplicationUserRole>(applicationUserRole =>
            {
                applicationUserRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                applicationUserRole.HasOne(ur => ur.ApplicationRole)
                    .WithMany(ur => ur.ApplicationUserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                applicationUserRole.HasOne(ur => ur.ApplicationUser)
                    .WithMany(ur => ur.ApplicationUserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}