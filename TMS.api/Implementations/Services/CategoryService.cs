using AutoMapper;
using TMS.api.DataTransferObjects;
using TMS.api.Entities;
using TMS.api.Interfaces.Repositories;
using TMS.api.Interfaces.Services;
using TMS.api.Persistance;

namespace TMS.api.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IdDto<int>> AddCategoryAsync(CategoryDto dto)
        {
            var mappedEntity = _mapper.Map<Category>(dto);
            mappedEntity.CreatedAt = DateTime.UtcNow;

            _categoryRepository.AddCategory(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            return new IdDto<int>
            {
                Id = mappedEntity.Id
            };
        }

        public async Task<IList<IdDto<int>>> BulkInsertCategory(IList<CategoryDto> dtoList)
        {
            var entityList = _mapper.Map<IList<Category>>(dtoList);
            _categoryRepository.BulkInsertCategory(entityList);

            await _unitOfWork.SaveChangesAsync();
            return entityList.Select(x => new IdDto<int> { Id = x.Id }).ToList();
        }
    }
}
