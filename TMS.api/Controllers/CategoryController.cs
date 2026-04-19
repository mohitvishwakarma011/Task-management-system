using Microsoft.AspNetCore.Mvc;
using TMS.api.DataTransferObjects;
using TMS.api.Interfaces.Services;

namespace TMS.api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto dto)
        {
            return Ok(await _categoryService.AddCategoryAsync(dto));
        }

        [HttpPost("bulk-insert")]
        public async Task<IActionResult> BulkInsertCategory(IList<CategoryDto> categoryDtoList)
        {
            return Ok(await _categoryService.BulkInsertCategory(categoryDtoList));
        }
    }
}
