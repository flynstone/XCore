using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Rental>> GetRentalsAsync(bool trackChanges) => (IEnumerable<Rental>)await this.FindAll(trackChanges).Include<Rental, Customer>((Expression<Func<Rental, Customer>>)(c => c.Customer)).OrderBy<Rental, Customer>((Expression<Func<Rental, Customer>>)(c => c.Customer)).Include<Rental, Media>((Expression<Func<Rental, Media>>)(c => c.Media)).ThenInclude<Rental, Media, Category>((Expression<Func<Media, Category>>)(x => x.ItemCategory)).ToListAsync<Rental>();

        public async Task<Rental> GetRentalAsync(int rentalId, bool trackChanges) => await this.FindByCondition((Expression<Func<Rental, bool>>)(c => c.RentalId.Equals(rentalId)), (trackChanges ? 1 : 0) != 0).Include<Rental, Customer>((Expression<Func<Rental, Customer>>)(c => c.Customer)).Include<Rental, Media>((Expression<Func<Rental, Media>>)(c => c.Media)).SingleOrDefaultAsync<Rental>();

        public void CreateRental(Rental rental) => this.Create(rental);

        public void UpdateRental(Rental rental) => this.Update(rental);

        public void DeleteRental(Rental rental) => this.Delete(rental);
    }
}
