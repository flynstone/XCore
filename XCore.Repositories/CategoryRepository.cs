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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(XCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges)
        {
            return (IEnumerable<Category>)await this.FindAll(trackChanges).OrderBy<Category, string>((Expression<Func<Category, string>>)(c => c.Description)).ToListAsync<Category>();
        }

        public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges) => await this.FindByCondition((Expression<Func<Category, bool>>)(c => c.CategoryId.Equals(categoryId)), (trackChanges ? 1 : 0) != 0).SingleOrDefaultAsync<Category>();

        public void CreateCategory(Category category) => this.Create(category);

        public void UpdateCategory(Category category) => this.Update(category);

        public void DeleteCategory(Category category) => this.Delete(category);
    }
}
