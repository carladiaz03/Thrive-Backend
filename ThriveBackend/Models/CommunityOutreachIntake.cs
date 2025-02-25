using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriveBackend.Models
{
    public class CommunityOutreachIntake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-Incremented
        public int RefugeeID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public string NavigatorName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }

        [Required]
        public string PreferredLanguage { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string MailingAddress { get; set; }

        [Required]
        public string CurrentImmigrationStatus { get; set; }
    }
}
