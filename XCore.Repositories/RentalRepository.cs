using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.Models.Rentals;
using XCore.Repositories.Interfaces;

namespace XCore.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .Include(c => c.Customer)
            .OrderBy(c => c.Customer)
            .Include(c => c.Media)
            .ThenInclude(x => x.ItemCategory)
            .ToListAsync();

        public async Task<Rental> GetRentalAsync(int rentalId, bool trackChanges) => 
            await FindByCondition(c => c.RentalId.Equals(rentalId), (trackChanges ? 1 : 0) != 0)
            .Include(c => c.Customer)
            .Include(c => c.Media)
            .SingleOrDefaultAsync();

        public void CreateRental(Rental rental) => 
            Create(rental);

        public void UpdateRental(Rental rental) => 
            Update(rental);

        public void DeleteRental(Rental rental) => 
            Delete(rental);
    }
}
