using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Rentals;

namespace XCore.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(bool trackChanges);

        Task<Customer> GetCustomerAsync(int customerId, bool trackChanges);

        void CreateCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
