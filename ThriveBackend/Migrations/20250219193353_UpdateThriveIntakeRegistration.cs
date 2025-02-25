using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThriveBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThriveIntakeRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EligibilityDate",
                table: "ThriveIntakeRegistrations",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CaseWorker",
                table: "ThriveIntakeRegistrations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "ThriveIntakeRegistrations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AlienNumber",
                table: "ThriveIntakeRegistrations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AsylumDateGranted",
                table: "ThriveIntakeRegistrations",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlienNumber",
                table: "ThriveIntakeRegistrations");

            migrationBuilder.DropColumn(
                name: "AsylumDateGranted",
                table: "ThriveIntakeRegistrations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EligibilityDate",
                table: "ThriveIntakeRegistrations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CaseWorker",
                table: "ThriveIntakeRegistrations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "ThriveIntakeRegistrations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
