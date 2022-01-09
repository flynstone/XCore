using Microsoft.EntityFrameworkCore;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities.Seeds
{
    public static class SeedRentalProject
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
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

            modelBuilder.Entity<Media>().HasData(
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
                }
           );
        }

    }
}
