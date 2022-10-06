using Microsoft.EntityFrameworkCore;

namespace AVIRApi.Models
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
            : base(options)
        {
        }
        public DbSet<IncidentReport> IncidentReports { get; set; } = null!;
        public DbSet<ThreatProfile> ThreatProfiles {get; set;} = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
          
          
        //    modelBuilder.Entity<ThreatProfile>()
        //         .Property(p => p.Age )
        //         .HasDefaultValue("24");
        //     modelBuilder.Entity<ThreatProfile>()
        //         .Property(p => p.LastSeen )
        //         .HasDefaultValue("6");
        //     modelBuilder.Entity<ThreatProfile>()
        //         .Property(p => p.NumOccurences )
        //         .HasDefaultValue("4");
        //                 modelBuilder.Entity<ThreatProfile>()
        //         .Property(p => p.LocationFrequency )
        //         .HasDefaultValue("1");


                
        }
    }
}