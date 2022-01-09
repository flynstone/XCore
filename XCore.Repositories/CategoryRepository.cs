using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.Models.Rentals;
using XCore.Repositories.Interfaces;

namespace XCore.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Description).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges) => 
            await FindByCondition(c => c.CategoryId.Equals(categoryId), (trackChanges ? 1 : 0) != 0)
            .SingleOrDefaultAsync();

        public void CreateCategory(Category category) => 
            Create(category);

        public void UpdateCategory(Category category) => 
            Update(category);

        public void DeleteCategory(Category category) => 
            Delete(category);
    }
}
