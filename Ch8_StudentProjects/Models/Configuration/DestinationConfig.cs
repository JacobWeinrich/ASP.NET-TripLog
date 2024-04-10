using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ch8_StudentProjects.Models.Configuration
{
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasData(new Destination { DestinationId = 1, Name = "Vegas" });
        }
    }
}
