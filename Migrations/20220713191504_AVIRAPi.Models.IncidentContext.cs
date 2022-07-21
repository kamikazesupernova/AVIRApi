using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AVIRApi.Migrations
{
    public partial class AVIRAPiModelsIncidentContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThreatProfiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false, defaultValue: 24L),
                    LastSeen = table.Column<long>(type: "bigint", nullable: false, defaultValue: 6L),
                    NumOccurences = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    LocationFrequency = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreatProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThreatProfiles_IncidentReports_IncidentReportID",
                        column: x => x.IncidentReportID,
                        principalTable: "IncidentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreatProfiles");
        }
    }
}
