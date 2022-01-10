using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasData(
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
