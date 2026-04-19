using TMS.api.DataTransferObjects;

namespace TMS.api.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IdDto<int>> AddCategoryAsync(CategoryDto dto);
        Task<IList<IdDto<int>>> BulkInsertCategory(IList<CategoryDto> dto);
    }
}
