using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ch8_StudentProjects.Models.Configuration
{
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(new Activity { ActivityId = 1, Name = "Gambling" });
        }
    }
}
