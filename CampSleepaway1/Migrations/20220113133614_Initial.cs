using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepaway1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CapacityCampers = table.Column<int>(type: "int", nullable: false),
                    CapacityCounselor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                });

            migrationBuilder.CreateTable(
                name: "CamperStays",
                columns: table => new
                {
                    CamperStayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CamperStayId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperStays", x => x.CamperStayId);
                    table.ForeignKey(
                        name: "FK_CamperStays_Cabins_CamperStayId1",
                        column: x => x.CamperStayId1,
                        principalTable: "Cabins",
                        principalColumn: "CabinId");
                });

            migrationBuilder.CreateTable(
                name: "CounselorStays",
                columns: table => new
                {
                    CounselorStayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CounselorStayId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounselorStays", x => x.CounselorStayId);
                    table.ForeignKey(
                        name: "FK_CounselorStays_Cabins_CounselorStayId1",
                        column: x => x.CounselorStayId1,
                        principalTable: "Cabins",
                        principalColumn: "CabinId");
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    CounselorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CounselorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.CounselorId);
                    table.ForeignKey(
                        name: "FK_Counselors_CounselorStays_CounselorId1",
                        column: x => x.CounselorId1,
                        principalTable: "CounselorStays",
                        principalColumn: "CounselorStayId");
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CamperId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperId);
                    table.ForeignKey(
                        name: "FK_Campers_CamperStays_CamperId1",
                        column: x => x.CamperId1,
                        principalTable: "CamperStays",
                        principalColumn: "CamperStayId");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxVisitTime = table.Column<int>(type: "int", nullable: false),
                    EarliestVisit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LatestVisit = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    VisitId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Campers_VisitId1",
                        column: x => x.VisitId1,
                        principalTable: "Campers",
                        principalColumn: "CamperId");
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NextOfKinId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinId);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Visit_NextOfKinId1",
                        column: x => x.NextOfKinId1,
                        principalTable: "Visit",
                        principalColumn: "VisitId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CamperId1",
                table: "Campers",
                column: "CamperId1");

            migrationBuilder.CreateIndex(
                name: "IX_CamperStays_CamperStayId1",
                table: "CamperStays",
                column: "CamperStayId1");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CounselorId1",
                table: "Counselors",
                column: "CounselorId1");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorStays_CounselorStayId1",
                table: "CounselorStays",
                column: "CounselorStayId1");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_NextOfKinId1",
                table: "NextOfKins",
                column: "NextOfKinId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_VisitId1",
                table: "Visit",
                column: "VisitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_NextOfKins_CamperId1",
                table: "Campers",
                column: "CamperId1",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_CamperStays_CamperId1",
                table: "Campers");

            migrationBuilder.DropForeignKey(
                name: "FK_Campers_NextOfKins_CamperId1",
                table: "Campers");

            migrationBuilder.DropTable(
                name: "Counselors");

            migrationBuilder.DropTable(
                name: "CounselorStays");

            migrationBuilder.DropTable(
                name: "CamperStays");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Campers");
        }
    }
}
