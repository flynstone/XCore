using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Rentals;

namespace XCore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
