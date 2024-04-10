using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Ch8_StudentProjects.Models.Configuration
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity.HasOne(t => t.Destination).WithMany(d => d.Trips).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(t => t.Accommodation).WithMany(a => a.Trips).OnDelete(DeleteBehavior.Restrict);


            entity.HasMany(t => t.Activities).WithMany(a => a.Trips).UsingEntity<Dictionary<string, object>>(
                "TripActivity",
                  j => j.HasOne<Activity>().WithMany().HasForeignKey("ActivityId"),
                  j => j.HasOne<Trip>().WithMany().HasForeignKey("TripId"),
                  j =>
                  {
                      j.HasData(new { TripId = 1, ActivityId = 1 });
                  });



            entity.HasData(
                        new Trip
                        {
                            TripId = 1,
                            DestinationId = 1,
                            StartDate = new DateTime(2024, 6, 1),
                            EndDate = new DateTime(2024, 6, 5),
                            AccommodationId = 1,
                        });
        }
    }
}
