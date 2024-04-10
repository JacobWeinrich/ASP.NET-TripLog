using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ch8_StudentProjects.Models.Configuration
{
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.HasData(new Accommodation { AccommodationId = 1, Name = "The Plaza", AccommodationEmail = "info@example.com", AccommodationPhone = "555-555-5555" });

        }
    }
}
