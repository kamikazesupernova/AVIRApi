using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AVIRApi.Migrations
{
    public partial class AVIRAPiModelsIncidentContext4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confidence",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "WinEndTime",
                table: "IncidentReports");

            migrationBuilder.DropColumn(
                name: "WinStartTime",
                table: "IncidentReports");

            migrationBuilder.AlterColumn<double>(
                name: "GPSLongitude",
                table: "Node",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "GPSLatitude",
                table: "Node",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "GPSLongitude",
                table: "Node",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GPSLatitude",
                table: "Node",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Confidence",
                table: "IncidentReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "WinEndTime",
                table: "IncidentReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WinStartTime",
                table: "IncidentReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
