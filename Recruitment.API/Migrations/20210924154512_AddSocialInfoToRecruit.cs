using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment.API.Migrations
{
    public partial class AddSocialInfoToRecruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Recruits",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Google",
                table: "Recruits",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Recruits",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Recruits",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Recruits");

            migrationBuilder.DropColumn(
                name: "Google",
                table: "Recruits");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Recruits");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Recruits");
        }
    }
}
