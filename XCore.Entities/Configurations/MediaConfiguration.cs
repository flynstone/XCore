using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasData(
                new Media
                {
                    MediaId= 1,
                    ItemTitle = "21 Jump Street (2012)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 2,
                    ItemTitle = "21 Jump Street (2012)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 3,
                    ItemTitle = "22 Jump Street (2014)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 4,
                    ItemTitle = "22 Jump Street (2014)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 5,
                    ItemTitle = "Orphan (2009)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 6,
                    ItemTitle = "Orphan (2009)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 7,
                    ItemTitle = "Orphan (2009)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 8,
                    ItemTitle = "Orphan (2009)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 9,
                    ItemTitle = "The Blair Witch Project (1999)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 10,
                    ItemTitle = "The Blair Witch Project (1999)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 11,
                    ItemTitle = "The Day After Tomorrow (2004)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 12,
                    ItemTitle = "The Day After Tomorrow (2004)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 13,
                    ItemTitle = "De père en flic (2009)",
                    CategoryId = 1
                },
                new Media
                {
                    MediaId = 14,
                    ItemTitle = "De père en flic (2009)",
                    CategoryId = 2
                },
                new Media
                {
                    MediaId = 15,
                    ItemTitle = "Grand Theft Auto V",
                    CategoryId = 3
                },
                new Media
                {
                    MediaId = 16,
                    ItemTitle = "Red Dead Redemption",
                    CategoryId = 3
                },
                new Media
                {
                    MediaId = 17,
                    ItemTitle = "Witcher 3",
                    CategoryId = 3
                },
                new Media
                {
                    MediaId = 18,
                    ItemTitle = "Conan Exiles",
                    CategoryId = 3
                },
                new Media
                {
                    MediaId = 19,
                    ItemTitle = "Minecraft",
                    CategoryId = 3
                },
                new Media
                {
                    MediaId = 20,
                    ItemTitle = "Sekiro",
                    CategoryId = 3
                }
           );
        }
    }
}
