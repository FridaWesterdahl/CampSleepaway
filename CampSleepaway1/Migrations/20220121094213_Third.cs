using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepaway1.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounselerId",
                table: "CounselorStays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounselerId",
                table: "CounselorStays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
