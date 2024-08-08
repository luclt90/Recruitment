using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    CareerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.CareerId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên ngành")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên tỉnh/thành phố")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "CompanySizes",
                columns: table => new
                {
                    CompanySizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true),
                    Show = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySizes", x => x.CompanySizeId);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<double>(type: "float", nullable: true),
                    Max = table.Column<double>(type: "float", nullable: true),
                    Show = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "LevelInfos",
                columns: table => new
                {
                    LevelInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên trình độ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelInfos", x => x.LevelInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<double>(type: "float", nullable: true),
                    Max = table.Column<double>(type: "float", nullable: true),
                    Show = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Giá hiển thị")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    WebsiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banner = table.Column<string>(type: "ntext", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Banner2 = table.Column<string>(type: "ntext", nullable: true),
                    Banner3 = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.WebsiteId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên loại hình làm việc")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.WorkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webmasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true, comment: "Thể loại"),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "Trạng thái"),
                    Gender = table.Column<int>(type: "int", nullable: true, comment: "Giới tính"),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true, comment: "Ngày sinh"),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày bắt đầu"),
                    Address = table.Column<string>(type: "ntext", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true, comment: "Vị trí làm việc")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webmasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webmasters_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên công việc"),
                    CareerId = table.Column<int>(type: "int", nullable: true, comment: "Mã ngành")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                    table.ForeignKey(
                        name: "FK_Professions_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "CareerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên quận/huyện"),
                    CityId = table.Column<int>(type: "int", nullable: true, comment: "Mã tỉnh/thành phố")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Tiêu đề"),
                    Quote = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả ngắn gọn"),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Chi tiết"),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày đăng"),
                    PublicDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày duyệt"),
                    Type = table.Column<int>(type: "int", nullable: true, comment: "Thể loại"),
                    WebmasterId = table.Column<int>(type: "int", nullable: true, comment: "Mã người đăng"),
                    CategoryId = table.Column<int>(type: "int", nullable: true, comment: "Mã chuyên mục"),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "Trạng thái"),
                    Avatar = table.Column<string>(type: "ntext", nullable: true, comment: "Ảnh đại diện")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewId);
                    table.ForeignKey(
                        name: "FK_News_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Webmasters_WebmasterId",
                        column: x => x.WebmasterId,
                        principalTable: "Webmasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Tên xã/phường"),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Ảnh đại diện"),
                    Sex = table.Column<int>(type: "int", nullable: true, comment: "Giới tính"),
                    About = table.Column<string>(type: "ntext", nullable: true, comment: "Giới thiệu bản thân"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Vị trí"),
                    ExperienceInfo = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả kinh nghiệm"),
                    Speciality = table.Column<string>(type: "ntext", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày đăng ký"),
                    Facebook = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Google = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfessionId = table.Column<int>(type: "int", nullable: true),
                    LevelInfoId = table.Column<int>(type: "int", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: true),
                    SalaryId = table.Column<int>(type: "int", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PathCV = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    DescribeCV = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả CV")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_LevelInfos_LevelInfoId",
                        column: x => x.LevelInfoId,
                        principalTable: "LevelInfos",
                        principalColumn: "LevelInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "WorkTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recruits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    About = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả công ty"),
                    Logo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Logo công ty"),
                    Address = table.Column<string>(type: "ntext", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày đăng ký"),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "Trạng thái"),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FoundedYear = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Thời gian thành lập"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    CompanySizeId = table.Column<int>(type: "int", nullable: true),
                    ProfessionId = table.Column<int>(type: "int", nullable: true),
                    CoverImage = table.Column<string>(type: "ntext", nullable: true, comment: "Ảnh bìa"),
                    Avatar = table.Column<string>(type: "ntext", nullable: true, comment: "Ảnh đại diện")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruits_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recruits_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recruits_CompanySizes_CompanySizeId",
                        column: x => x.CompanySizeId,
                        principalTable: "CompanySizes",
                        principalColumn: "CompanySizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recruits_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruits_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recruits_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecruitJobs",
                columns: table => new
                {
                    RecruitJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Tiêu đề"),
                    Position = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Vị trí tuyển dụng"),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true, comment: "Số lượng"),
                    Describe = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả công việc"),
                    Require = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả yêu cầu"),
                    Benefit = table.Column<string>(type: "ntext", nullable: true, comment: "Mô tả lợi ích"),
                    WorkPlace = table.Column<string>(type: "ntext", nullable: true, comment: "Nơi làm việc"),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày đăng"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày hết hạn"),
                    EmailContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NameContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneContact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true, comment: "Trạng thái"),
                    Type = table.Column<int>(type: "int", nullable: true, comment: "Thể loại"),
                    SalaryId = table.Column<int>(type: "int", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    RecruitId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    ProfessionId = table.Column<int>(type: "int", nullable: true),
                    LevelInfoId = table.Column<int>(type: "int", nullable: true, comment: "Mã trình độ"),
                    WorkTypeId = table.Column<int>(type: "int", nullable: true, comment: "Mã thể loại làm việc"),
                    Count = table.Column<int>(type: "int", nullable: true, comment: "Số lượng xem tin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitJobs", x => x.RecruitJobId);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_LevelInfos_LevelInfoId",
                        column: x => x.LevelInfoId,
                        principalTable: "LevelInfos",
                        principalColumn: "LevelInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Recruits_RecruitId",
                        column: x => x.RecruitId,
                        principalTable: "Recruits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "WardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecruitJobs_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "WorkTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaveCandidates",
                columns: table => new
                {
                    SaveCandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    RecruitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveCandidates", x => x.SaveCandidateId);
                    table.ForeignKey(
                        name: "FK_SaveCandidates_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaveCandidates_Recruits_RecruitId",
                        column: x => x.RecruitId,
                        principalTable: "Recruits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePostResumes",
                columns: table => new
                {
                    CandidatePostResumeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    RecruitJobId = table.Column<int>(type: "int", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ngày ứng tuyển"),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PathFileCV = table.Column<string>(type: "ntext", nullable: true, comment: "Link CV")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePostResumes", x => x.CandidatePostResumeId);
                    table.ForeignKey(
                        name: "FK_CandidatePostResumes_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidatePostResumes_RecruitJobs_RecruitJobId",
                        column: x => x.RecruitJobId,
                        principalTable: "RecruitJobs",
                        principalColumn: "RecruitJobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaveJobs",
                columns: table => new
                {
                    SaveJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: true, comment: "Mã người tìm việc"),
                    RecruitJobId = table.Column<int>(type: "int", nullable: true, comment: "Mã người tuyển dụng"),
                    Status = table.Column<bool>(type: "bit", nullable: true, comment: "Trạng thái")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveJobs", x => x.SaveJobId);
                    table.ForeignKey(
                        name: "FK_SaveJobs_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaveJobs_RecruitJobs_RecruitJobId",
                        column: x => x.RecruitJobId,
                        principalTable: "RecruitJobs",
                        principalColumn: "RecruitJobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "ApplicationRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePostResumes_CandidateId",
                table: "CandidatePostResumes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePostResumes_RecruitJobId",
                table: "CandidatePostResumes",
                column: "RecruitJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CityId",
                table: "Candidates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_DistrictId",
                table: "Candidates",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ExperienceId",
                table: "Candidates",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_LevelInfoId",
                table: "Candidates",
                column: "LevelInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ProfessionId",
                table: "Candidates",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SalaryId",
                table: "Candidates",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_WardId",
                table: "Candidates",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_WorkTypeId",
                table: "Candidates",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_WebmasterId",
                table: "News",
                column: "WebmasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_CareerId",
                table: "Professions",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_CityId",
                table: "RecruitJobs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_DistrictId",
                table: "RecruitJobs",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_ExperienceId",
                table: "RecruitJobs",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_LevelInfoId",
                table: "RecruitJobs",
                column: "LevelInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_ProfessionId",
                table: "RecruitJobs",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_RecruitId",
                table: "RecruitJobs",
                column: "RecruitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_SalaryId",
                table: "RecruitJobs",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_WardId",
                table: "RecruitJobs",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitJobs_WorkTypeId",
                table: "RecruitJobs",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruits_CityId",
                table: "Recruits",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruits_CompanySizeId",
                table: "Recruits",
                column: "CompanySizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruits_DistrictId",
                table: "Recruits",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruits_ProfessionId",
                table: "Recruits",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruits_WardId",
                table: "Recruits",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveCandidates_CandidateId",
                table: "SaveCandidates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveCandidates_RecruitId",
                table: "SaveCandidates",
                column: "RecruitId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveJobs_CandidateId",
                table: "SaveJobs",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveJobs_RecruitJobId",
                table: "SaveJobs",
                column: "RecruitJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DistrictId",
                table: "Wards",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CandidatePostResumes");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "SaveCandidates");

            migrationBuilder.DropTable(
                name: "SaveJobs");

            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Webmasters");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "RecruitJobs");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "LevelInfos");

            migrationBuilder.DropTable(
                name: "Recruits");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CompanySizes");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
