using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThriveBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddRefugeeIDToStudentAndOutreach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityOutreachIntakes",
                columns: table => new
                {
                    RefugeeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    NavigatorName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "text", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    MailingAddress = table.Column<string>(type: "text", nullable: false),
                    CurrentImmigrationStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityOutreachIntakes", x => x.RefugeeID);
                });

            migrationBuilder.CreateTable(
                name: "NewStudentRegistrations",
                columns: table => new
                {
                    RefugeeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    School = table.Column<string>(type: "text", nullable: false),
                    CurrentGrade = table.Column<string>(type: "text", nullable: false),
                    LanguagesSpoken = table.Column<string>(type: "text", nullable: false),
                    ParentName = table.Column<string>(type: "text", nullable: false),
                    ParentLanguagesSpoken = table.Column<string>(type: "text", nullable: false),
                    ParentPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ParentEmail = table.Column<string>(type: "text", nullable: false),
                    PreferredContactMethod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewStudentRegistrations", x => x.RefugeeID);
                });

            migrationBuilder.CreateTable(
                name: "Refugees",
                columns: table => new
                {
                    RefugeeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refugees", x => x.RefugeeID);
                });

            migrationBuilder.CreateTable(
                name: "ThriveIntakeRegistrations",
                columns: table => new
                {
                    RefugeeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ProgramType = table.Column<string>(type: "text", nullable: false),
                    IntakeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NavigatorName = table.Column<string>(type: "text", nullable: false),
                    CurrentImmigrationStatus = table.Column<string>(type: "text", nullable: false),
                    EligibilityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CaseWorker = table.Column<string>(type: "text", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThriveIntakeRegistrations", x => x.RefugeeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityOutreachIntakes");

            migrationBuilder.DropTable(
                name: "NewStudentRegistrations");

            migrationBuilder.DropTable(
                name: "Refugees");

            migrationBuilder.DropTable(
                name: "ThriveIntakeRegistrations");
        }
    }
}
