using TMS.api.Entities;
using TMS.api.Interfaces.Repositories;
using TMS.api.Persistance;

namespace TMS.api.Implementations.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddCategory(Category category)
        {
            _appDbContext.Category.Add(category);
        }

        public void BulkInsertCategory(IList<Category> categoryList)
        {
            _appDbContext.Category.AddRange(categoryList);
        }
    }
}
