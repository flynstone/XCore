using Microsoft.EntityFrameworkCore;
using System;
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

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Shaelyn",
                    LastName = " Mayson",
                    Address = "123 Fake Street"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = " Byrne",
                    LastName = "Harvey",
                    Address = "337 Lost Street"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Benny",
                    LastName = "Shana",
                    Address = "456 Fake Boulevard"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = " Xzavier",
                    LastName = "Tawnie",
                    Address = "98 Main Street"
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Flo",
                    LastName = "Sondra",
                    Address = "123 County Road"
                },
                new Customer
                {
                    CustomerId = 6,
                    FirstName = "Leatrice",
                    LastName = "Paul",
                    Address = "223 Fake Street"
                },
                new Customer
                {
                    CustomerId = 7,
                    FirstName = "Braeden",
                    LastName = "Mayson",
                    Address = "456 Fake Boulevard"
                },
                new Customer
                {
                    CustomerId = 8,
                    FirstName = "Angela",
                    LastName = "Callan",
                    Address = "98 Main Street"
                },
                new Customer
                {
                    CustomerId = 9,
                    FirstName = " Lydia",
                    LastName = "Gavin",
                    Address = "123 County Road"
                },
                new Customer
                {
                    CustomerId = 10,
                    FirstName = "Jess",
                    LastName = "Autumn",
                    Address = "223 Fake Street"
                }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    RentalId = 1,
                    DateOfRental = new DateTime(2021, 2, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 1,
                    MediaId = 1
                },
                new Rental
                {
                    RentalId = 2,
                    DateOfRental = new DateTime(2021, 2, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 2,
                    MediaId = 5
                },
                new Rental
                {
                    RentalId = 3,
                    DateOfRental = new DateTime(2022, 1, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 3,
                    MediaId = 2
                },
                new Rental
                {
                    RentalId = 4,
                    DateOfRental = new DateTime(2021, 2, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 4,
                    MediaId = 4
                },
                new Rental
                {
                    RentalId = 5,
                    DateOfRental = new DateTime(2021, 2, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 5,
                    MediaId = 1
                },
                new Rental
                {
                    RentalId = 6,
                    DateOfRental = new DateTime(2021, 2, 9),
                    DueDate = new DateTime(2021, 2, 12),
                    IsReturned = true,
                    CustomerId = 6,
                    MediaId = 8
                },
                new Rental
                {
                    RentalId = 7,
                    DateOfRental = new DateTime(2021, 2, 10),
                    DueDate = new DateTime(2021, 2, 13),
                    IsReturned = true,
                    CustomerId = 7,
                    MediaId = 7
                },
                new Rental
                {
                    RentalId = 8,
                    DateOfRental = new DateTime(2021, 2, 10),
                    DueDate = new DateTime(2021, 2, 13),
                    IsReturned = true,
                    CustomerId = 8,
                    MediaId = 6
                },
                new Rental
                {
                    RentalId = 9,
                    DateOfRental = new DateTime(2021, 2, 10),
                    DueDate = new DateTime(2021, 2, 13),
                    IsReturned = true,
                    CustomerId = 9,
                    MediaId = 14
                },
                new Rental
                {
                    RentalId = 10,
                    DateOfRental = new DateTime(2021, 2, 10),
                    DueDate = new DateTime(2021, 2, 13),
                    IsReturned = true,
                    CustomerId = 10,
                    MediaId = 12
                },
                new Rental
                {
                    RentalId = 11,
                    DateOfRental = new DateTime(2021, 2, 12),
                    DueDate = new DateTime(2021, 2, 15),
                    IsReturned = true,
                    CustomerId = 1,
                    MediaId = 10
                },
                new Rental
                {
                    RentalId = 12,
                    DateOfRental = new DateTime(2021, 2, 12),
                    DueDate = new DateTime(2021, 2, 15),
                    IsReturned = true,
                    CustomerId = 2,
                    MediaId = 18
                },
                new Rental
                {
                    RentalId = 13,
                    DateOfRental = new DateTime(2021, 2, 12),
                    DueDate = new DateTime(2021, 2, 15),
                    IsReturned = true,
                    CustomerId = 3,
                    MediaId = 1
                },
                new Rental
                {
                    RentalId = 14,
                    DateOfRental = new DateTime(2021, 2, 12),
                    DueDate = new DateTime(2021, 2, 15),
                    IsReturned = true,
                    CustomerId = 4,
                    MediaId = 2
                },
                new Rental
                {
                    RentalId = 15,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 5,
                    MediaId = 30
                },
                new Rental
                {
                    RentalId = 16,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 6,
                    MediaId = 17
                },
                new Rental
                {
                    RentalId = 17,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 7,
                    MediaId = 16
                },
                new Rental
                {
                    RentalId = 18,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 8,
                    MediaId = 9
                },
                new Rental
                {
                    RentalId = 19,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 9,
                    MediaId = 8
                },
                new Rental
                {
                    RentalId = 20,
                    DateOfRental = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 6),
                    IsReturned = true,
                    CustomerId = 10,
                    MediaId = 5
                }
            );
        }

    }
}
