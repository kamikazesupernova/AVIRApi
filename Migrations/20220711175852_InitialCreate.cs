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
                    WinStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CeaseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confidence = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentReports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attach",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Ref = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEncoding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AggrWin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPSLatitude = table.Column<long>(type: "bigint", nullable: false),
                    GPSLongitude = table.Column<long>(type: "bigint", nullable: false),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPSSpeed = table.Column<long>(type: "bigint", nullable: false),
                    GPSDirection = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachHand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Netname = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spoofed = table.Column<bool>(type: "bit", nullable: false),
                    IP4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IncidentReports");
        }
    }
}
