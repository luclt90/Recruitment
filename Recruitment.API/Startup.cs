using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Recruitment.API.Data;
using Recruitment.API.Helpers;
using Recruitment.API.Helpers.Extensions;
using Recruitment.API.Models;
using Recruitment.API.Repositories;

namespace Recruitment.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<RecruitmentDbContext>(x =>
            {
                x.UseLazyLoadingProxies();
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            IdentityBuilder builder = services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<RecruitmentDbContext>();
            builder.AddRoleValidator<RoleValidator<ApplicationRole>>();
            builder.AddRoleManager<RoleManager<ApplicationRole>>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddScoped(typeof(IRecruitmentRepository<>), typeof(RecruitmentRepository<>));
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICareerRepository, CareerRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IRecruitJobRepository, RecruitJobRepository>();
            services.AddScoped<IRecruitRepository, RecruitRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<ICompanySizeRepository, CompanySizeRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ILevelInfoRepository, LevelInfoRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<ICandidatePostResumeRepository, CandidatePostResumeRepository>();

            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recruitment.API", Version = "v1" });
            // });
            //TODO: remove de Bao mat
            services.AddCors(options =>{
                options.AddPolicy("Any",
            builder =>
            {
                builder
                    //.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    
                    .AllowCredentials()
                    .SetIsOriginAllowed(host => true);
                    
            });
            
        options.AddPolicy("Production",
            builder => 
            { 
                builder.WithOrigins("https://your-domain.com", "https://your-domain.com"); 
            });
            });
            
            services.AddAutoMapper(typeof(RecruitmentRepository<>).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //https://stackoverflow.com/questions/68788046/separate-webapi-from-angular-to-two-different-projects
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Any"); // Allow any origin
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruitment.API v1"));
            }
            else
            {
                 app.UseCors("Production");

                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();// Looking index.html in root SPA
            app.UseStaticFiles();//Auto look inside wwwroot
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //TODO: remove de Bao mat
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
                // endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
            });
        }
    }
}
