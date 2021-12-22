using System;
using System.Linq;
using System.Linq.Expressions;
using XCore.Entities.Models.Rentals;

namespace XCore.Repositories.Extensions
{
    public static class CustomerRepositoryExtensions
    {
        public static IQueryable<Customer> Search(
          this IQueryable<Customer> customers,
          string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return customers;
            return customers.Where<Customer>((Expression<Func<Customer, bool>>)(c => c.LastName.Contains(searchString) || c.FirstName.Contains(searchString)));
        }
    }
}
