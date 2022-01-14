using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepaway1.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_CamperStays_CamperId1",
                table: "Campers");

            migrationBuilder.DropForeignKey(
                name: "FK_Campers_NextOfKins_CamperId1",
                table: "Campers");

            migrationBuilder.DropForeignKey(
                name: "FK_CamperStays_Cabins_CamperStayId1",
                table: "CamperStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_CounselorStays_CounselorId1",
                table: "Counselors");

            migrationBuilder.DropForeignKey(
                name: "FK_CounselorStays_Cabins_CounselorStayId1",
                table: "CounselorStays");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Visit_NextOfKinId1",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Campers_VisitId1",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_VisitId1",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_NextOfKinId1",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_CounselorStays_CounselorStayId1",
                table: "CounselorStays");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_CounselorId1",
                table: "Counselors");

            migrationBuilder.DropIndex(
                name: "IX_CamperStays_CamperStayId1",
                table: "CamperStays");

            migrationBuilder.DropIndex(
                name: "IX_Campers_CamperId1",
                table: "Campers");

            migrationBuilder.DropColumn(
                name: "VisitId1",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "NextOfKinId1",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CounselorStayId1",
                table: "CounselorStays");

            migrationBuilder.DropColumn(
                name: "CounselorId1",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "CamperStayId1",
                table: "CamperStays");

            migrationBuilder.DropColumn(
                name: "CamperId1",
                table: "Campers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LatestVisit",
                table: "Visit",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EarliestVisit",
                table: "Visit",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "Visit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Visit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "CounselorStays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CounselerId",
                table: "CounselorStays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CounselorId",
                table: "CounselorStays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "CamperStays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "CamperStays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CamperNextOfKins",
                columns: table => new
                {
                    CamperNextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperNextOfKins", x => x.CamperNextOfKinId);
                    table.ForeignKey(
                        name: "FK_CamperNextOfKins_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperNextOfKins_NextOfKins_NextOfKinId",
                        column: x => x.NextOfKinId,
                        principalTable: "NextOfKins",
                        principalColumn: "NextOfKinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_CamperId",
                table: "Visit",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_NextOfKinId",
                table: "Visit",
                column: "NextOfKinId");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorStays_CabinId",
                table: "CounselorStays",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorStays_CounselorId",
                table: "CounselorStays",
                column: "CounselorId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperStays_CabinId",
                table: "CamperStays",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperStays_CamperId",
                table: "CamperStays",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperNextOfKins_CamperId",
                table: "CamperNextOfKins",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperNextOfKins_NextOfKinId",
                table: "CamperNextOfKins",
                column: "NextOfKinId");

            migrationBuilder.AddForeignKey(
                name: "FK_CamperStays_Cabins_CabinId",
                table: "CamperStays",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CamperStays_Campers_CamperId",
                table: "CamperStays",
                column: "CamperId",
                principalTable: "Campers",
                principalColumn: "CamperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CounselorStays_Cabins_CabinId",
                table: "CounselorStays",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CounselorStays_Counselors_CounselorId",
                table: "CounselorStays",
                column: "CounselorId",
                principalTable: "Counselors",
                principalColumn: "CounselorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Campers_CamperId",
                table: "Visit",
                column: "CamperId",
                principalTable: "Campers",
                principalColumn: "CamperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_NextOfKins_NextOfKinId",
                table: "Visit",
                column: "NextOfKinId",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CamperStays_Cabins_CabinId",
                table: "CamperStays");

            migrationBuilder.DropForeignKey(
                name: "FK_CamperStays_Campers_CamperId",
                table: "CamperStays");

            migrationBuilder.DropForeignKey(
                name: "FK_CounselorStays_Cabins_CabinId",
                table: "CounselorStays");

            migrationBuilder.DropForeignKey(
                name: "FK_CounselorStays_Counselors_CounselorId",
                table: "CounselorStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Campers_CamperId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_NextOfKins_NextOfKinId",
                table: "Visit");

            migrationBuilder.DropTable(
                name: "CamperNextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_Visit_CamperId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Visit_NextOfKinId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_CounselorStays_CabinId",
                table: "CounselorStays");

            migrationBuilder.DropIndex(
                name: "IX_CounselorStays_CounselorId",
                table: "CounselorStays");

            migrationBuilder.DropIndex(
                name: "IX_CamperStays_CabinId",
                table: "CamperStays");

            migrationBuilder.DropIndex(
                name: "IX_CamperStays_CamperId",
                table: "CamperStays");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "CounselorStays");

            migrationBuilder.DropColumn(
                name: "CounselerId",
                table: "CounselorStays");

            migrationBuilder.DropColumn(
                name: "CounselorId",
                table: "CounselorStays");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "CamperStays");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "CamperStays");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LatestVisit",
                table: "Visit",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EarliestVisit",
                table: "Visit",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "VisitId1",
                table: "Visit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId1",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CounselorStayId1",
                table: "CounselorStays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CounselorId1",
                table: "Counselors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamperStayId1",
                table: "CamperStays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamperId1",
                table: "Campers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitId1",
                table: "Visit",
                column: "VisitId1");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_NextOfKinId1",
                table: "NextOfKins",
                column: "NextOfKinId1");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorStays_CounselorStayId1",
                table: "CounselorStays",
                column: "CounselorStayId1");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CounselorId1",
                table: "Counselors",
                column: "CounselorId1");

            migrationBuilder.CreateIndex(
                name: "IX_CamperStays_CamperStayId1",
                table: "CamperStays",
                column: "CamperStayId1");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CamperId1",
                table: "Campers",
                column: "CamperId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_CamperStays_CamperId1",
                table: "Campers",
                column: "CamperId1",
                principalTable: "CamperStays",
                principalColumn: "CamperStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_NextOfKins_CamperId1",
                table: "Campers",
                column: "CamperId1",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinId");

            migrationBuilder.AddForeignKey(
                name: "FK_CamperStays_Cabins_CamperStayId1",
                table: "CamperStays",
                column: "CamperStayId1",
                principalTable: "Cabins",
                principalColumn: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_CounselorStays_CounselorId1",
                table: "Counselors",
                column: "CounselorId1",
                principalTable: "CounselorStays",
                principalColumn: "CounselorStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_CounselorStays_Cabins_CounselorStayId1",
                table: "CounselorStays",
                column: "CounselorStayId1",
                principalTable: "Cabins",
                principalColumn: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Visit_NextOfKinId1",
                table: "NextOfKins",
                column: "NextOfKinId1",
                principalTable: "Visit",
                principalColumn: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Campers_VisitId1",
                table: "Visit",
                column: "VisitId1",
                principalTable: "Campers",
                principalColumn: "CamperId");
        }
    }
}
