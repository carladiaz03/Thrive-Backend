using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriveBackend.Models
{
    public class Refugee
    {
        [Key]
        public long RefugeeID { get; set; } // ✅ Use manually generated unique long ID

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        // ✅ Constructor to Assign Random Unique ID
        public Refugee()
        {
            RefugeeID = GenerateUniqueRefugeeID();
        }

        // ✅ Method to Generate a Unique Long ID
        private static long GenerateUniqueRefugeeID()
        {
            Random random = new Random();
            return random.NextInt64(9000000, 9999999); // ✅ Generates a long between 9000000 and 9999999
        }
    }
}
