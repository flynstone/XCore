using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Rentals;

namespace XCore.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetRentalsAsync(bool trackChanges);

        Task<Rental> GetRentalAsync(int rentalId, bool trackChanges);

        void CreateRental(Rental rental);

        void UpdateRental(Rental rental);

        void DeleteRental(Rental rental);
    }
}
