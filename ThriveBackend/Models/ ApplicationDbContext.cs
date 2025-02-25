using Microsoft.EntityFrameworkCore;
using ThriveBackend.Models;

namespace ThriveBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // ✅ Ensure DbSets are properly defined
        public DbSet<ThriveIntakeRegistration> ThriveIntakeRegistrations { get; set; }
        public DbSet<NewStudentRegistration> NewStudentRegistrations { get; set; }
        public DbSet<CommunityOutreachIntake> CommunityOutreachIntakes { get; set; }
        public DbSet<Refugee> Refugees { get; set; } // ✅ Added

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Ensure `RefugeeID` is Auto-Incremented in PostgreSQL
            modelBuilder.Entity<Refugee>()
                .Property(r => r.RefugeeID)
                .ValueGeneratedOnAdd(); // ✅ Auto-Increment on Insert
        }
    }
}
