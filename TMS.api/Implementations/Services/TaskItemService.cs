using AutoMapper;
using TMS.api.DataTransferObjects;
using TMS.api.Entities;
using TMS.api.Interfaces.Repositories;
using TMS.api.Interfaces.Services;
using TMS.api.Persistance;
using TMS.api.Utils;

namespace TMS.api.Implementations.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TaskItemService(
            ITaskItemRepository taskItemRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork) {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IdDto<Guid>> CreateTaskItem(TaskItemDto dto)
        {
            var mappedEntity = _mapper.Map<TaskItem>(dto);
            mappedEntity.Id = Utility.GetUniquID();
            //mappedEntity.CreatedAt = 
            var result = await _taskItemRepository.CreateTask(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            return new IdDto<Guid>
            {
                Id = result,
            };
        }
    }
}
