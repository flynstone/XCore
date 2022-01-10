using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    Description = "Blu-Ray"
                },
                new Category
                {
                    CategoryId = 2,
                    Description = "DVD"
                },
                new Category
                {
                    CategoryId = 3,
                    Description = "Game"
                }
            );
        }
    }
}
