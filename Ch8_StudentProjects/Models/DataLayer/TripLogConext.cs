using Ch8_StudentProjects.Models.Configuration;
using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Ch8_StudentProjects.Models.DataLayer
{
    public class TripLogConext : DbContext
    {
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;


        public TripLogConext(DbContextOptions<TripLogConext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccommodationConfig());
            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new TripConfig());

        }
    }
}
