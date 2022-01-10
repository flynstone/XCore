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
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_context);
                return _customerRepository;
            }
        }

        public IMediaRepository Media
        {
            get
            {
                if (_mediaRepository == null)
                    _mediaRepository = new MediaRepository(_context);
                return _mediaRepository;
            }
        }

        public IRentalRepository Rental
        {
            get
            {
                if (_rentalRepository == null)
                    _rentalRepository = new RentalRepository(_context);
                return _rentalRepository;
            }
        }

        public async Task SaveAsync()
        {
            int num = await this._context.SaveChangesAsync();
        }
    }
}
