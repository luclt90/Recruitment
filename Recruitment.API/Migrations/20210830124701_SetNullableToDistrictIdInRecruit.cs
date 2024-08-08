using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment.API.Migrations
{
    public partial class SetNullableToDistrictIdInRecruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruits_Districts_DistrictId",
                table: "Recruits");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Recruits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Recruits_Districts_DistrictId",
                table: "Recruits",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruits_Districts_DistrictId",
                table: "Recruits");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Recruits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recruits_Districts_DistrictId",
                table: "Recruits",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
