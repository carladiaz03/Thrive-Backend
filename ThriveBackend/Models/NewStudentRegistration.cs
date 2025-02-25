using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriveBackend.Models
{
    public class NewStudentRegistration
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
        public string School { get; set; }

        [Required]
        public string CurrentGrade { get; set; }

        [Required]
        public string LanguagesSpoken { get; set; }

        [Required]
        public string ParentName { get; set; }

        [Required]
        public string ParentLanguagesSpoken { get; set; }

        [Required]
        public string ParentPhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string ParentEmail { get; set; }

        [Required]
        public string PreferredContactMethod { get; set; }
    }
}
