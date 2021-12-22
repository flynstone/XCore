using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XCore.Entities.Models.Overtime;

namespace XCore.Entities.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasData
                (
                    new Crew
                    {
                        Id = 1,
                        Name = "A"
                    },
                    new Crew
                    {
                        Id = 2,
                        Name = "B"
                    },
                    new Crew
                    {
                        Id = 3,
                        Name = "C"
                    },
                    new Crew
                    {
                        Id = 4,
                        Name = "D"
                    },
                    new Crew
                    {
                        Id = 5,
                        Name = "Days"
                    }
                );
        }
    }
}
