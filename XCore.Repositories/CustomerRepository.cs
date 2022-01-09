using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.Models.Rentals;
using XCore.Repositories.Interfaces;

namespace XCore.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(
          bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges) => 
            await FindByCondition(c => c.CustomerId.Equals(customerId), (trackChanges ? 1 : 0) != 0)
            .SingleOrDefaultAsync();

        public void CreateCustomer(Customer customer) => 
            Create(customer);

        public void UpdateCustomer(Customer customer) => 
            Update(customer);

        public void DeleteCustomer(Customer customer) => 
            Delete(customer);
    }
}
