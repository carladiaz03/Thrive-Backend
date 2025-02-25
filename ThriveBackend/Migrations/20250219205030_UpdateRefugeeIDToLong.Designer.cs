﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThriveBackend.Data;

#nullable disable

namespace ThriveBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250219205030_UpdateRefugeeIDToLong")]
    partial class UpdateRefugeeIDToLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThriveBackend.Models.CommunityOutreachIntake", b =>
                {
                    b.Property<int>("RefugeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RefugeeID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CurrentImmigrationStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MailingAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NavigatorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PreferredLanguage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RefugeeID");

                    b.ToTable("CommunityOutreachIntakes");
                });

            modelBuilder.Entity("ThriveBackend.Models.NewStudentRegistration", b =>
                {
                    b.Property<int>("RefugeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RefugeeID"));

                    b.Property<string>("CurrentGrade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LanguagesSpoken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentLanguagesSpoken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PreferredContactMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RefugeeID");

                    b.ToTable("NewStudentRegistrations");
                });

            modelBuilder.Entity("ThriveBackend.Models.Refugee", b =>
                {
                    b.Property<long>("RefugeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RefugeeID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RefugeeID");

                    b.ToTable("Refugees");
                });

            modelBuilder.Entity("ThriveBackend.Models.ThriveIntakeRegistration", b =>
                {
                    b.Property<long>("RefugeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RefugeeID"));

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AlienNumber")
                        .HasColumnType("text");

                    b.Property<DateTime?>("AsylumDateGranted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CaseWorker")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CurrentImmigrationStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EligibilityDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("IntakeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NavigatorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProgramType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RefugeeID");

                    b.ToTable("ThriveIntakeRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
