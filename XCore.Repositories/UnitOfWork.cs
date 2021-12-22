using System.Threading.Tasks;
using XCore.Entities;
using XCore.Repositories.Interfaces;

namespace XCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private XCoreDbContext _context;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IMediaRepository _mediaRepository;
        private IRentalRepository _rentalRepository;

        public UnitOfWork(XCoreDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository Category
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = (ICategoryRepository)new CategoryRepository(_context);
                return this._categoryRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (this._customerRepository == null)
                    this._customerRepository = (ICustomerRepository)new CustomerRepository(_context);
                return this._customerRepository;
            }
        }

        public IMediaRepository Media
        {
            get
            {
                if (this._mediaRepository == null)
                    this._mediaRepository = (IMediaRepository)new MediaRepository(_context);
                return this._mediaRepository;
            }
        }

        public IRentalRepository Rental
        {
            get
            {
                if (this._rentalRepository == null)
                    this._rentalRepository = (IRentalRepository)new RentalRepository(_context);
                return this._rentalRepository;
            }
        }

        public async Task SaveAsync()
        {
            int num = await this._context.SaveChangesAsync();
        }
    }
}
