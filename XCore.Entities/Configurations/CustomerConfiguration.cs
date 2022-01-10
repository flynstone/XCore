using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
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
        }
    }
   
}
