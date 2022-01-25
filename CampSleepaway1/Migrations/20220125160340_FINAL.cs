using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepaway1.Migrations
{
    public partial class FINAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarliestVisit",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "LatestVisit",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "MaxVisitTime",
                table: "Visit",
                newName: "VisitTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitTime",
                table: "Visit",
                newName: "MaxVisitTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EarliestVisit",
                table: "Visit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LatestVisit",
                table: "Visit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
