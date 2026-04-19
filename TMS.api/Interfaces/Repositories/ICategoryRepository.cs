using TMS.api.Entities;

namespace TMS.api.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void BulkInsertCategory(IList<Category> categoryList);
    }
}
