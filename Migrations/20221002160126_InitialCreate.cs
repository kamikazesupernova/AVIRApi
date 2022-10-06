using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AVIRApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentReports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetectTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CeaseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentReports", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Attach",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEncoding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attach", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attach_IncidentReports_IncidentReportID",
                        column: x => x.IncidentReportID,
                        principalTable: "IncidentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AggrWin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPSLatitude = table.Column<double>(type: "float", nullable: false),
                    GPSLongitude = table.Column<double>(type: "float", nullable: false),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPSSpeed = table.Column<long>(type: "bigint", nullable: false),
                    GPSDirection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Node_IncidentReports_IncidentReportID",
                        column: x => x.IncidentReportID,
                        principalTable: "IncidentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachHand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Netname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Source_IncidentReports_IncidentReportID",
                        column: x => x.IncidentReportID,
                        principalTable: "IncidentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spoofed = table.Column<bool>(type: "bit", nullable: false),
                    IP4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anonymised = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Target_IncidentReports_IncidentReportID",
                        column: x => x.IncidentReportID,
                        principalTable: "IncidentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attach_IncidentReportID",
                table: "Attach",
                column: "IncidentReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Node_IncidentReportID",
                table: "Node",
                column: "IncidentReportID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Source_IncidentReportID",
                table: "Source",
                column: "IncidentReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Target_IncidentReportID",
                table: "Target",
                column: "IncidentReportID");
                
            migrationBuilder.CreateIndex(
                name: "IX_ThreatProfiles_IncidentReportID",
                table: "ThreatProfiles",
                column: "IncidentReportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attach");

            migrationBuilder.DropTable(
                name: "Node");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Target");

            migrationBuilder.DropTable(
                name: "ThreatProfiles");

            migrationBuilder.DropTable(
                name: "IncidentReports");
        }
    }
}
