using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThriveBackend.Models
{
    public class ThriveIntakeRegistration
    {
        [Key] // ✅ Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ Auto-Incremented ID
        public long RefugeeID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ProgramType { get; set; } // ✅ Updated to store multiple selections as a comma-separated string

        [Required]
        public DateTime IntakeDate { get; set; }

        [Required]
        public string NavigatorName { get; set; }

        [Required]
        public string CurrentImmigrationStatus { get; set; } // ✅ Expecting single string instead of an array

        public DateTime? EligibilityDate { get; set; } // ✅ Nullable to prevent errors when empty
        public DateTime? AsylumDateGranted { get; set; } // ✅ Nullable
        public string? AlienNumber { get; set; } // ✅ Nullable

        // ✅ Additional Fields
        public string? CaseWorker { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow; // ✅ Auto-set to current date
        public string? AdditionalNotes { get; set; }
    }

    // ✅ Configuration Class
    public class ThriveIntakeRegistrationConfiguration : IEntityTypeConfiguration<ThriveIntakeRegistration>
    {
        public void Configure(EntityTypeBuilder<ThriveIntakeRegistration> builder)
        {
            builder.HasKey(t => t.RefugeeID); // ✅ Set Primary Key
        }
    }
}
