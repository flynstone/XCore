using System.Threading.Tasks;

namespace XCore.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        ICustomerRepository Customer { get; }

        IMediaRepository Media { get; }

        IRentalRepository Rental { get; }

        Task SaveAsync();
    }
}
