using AutoMapper;
using TMS.api.DataTransferObjects;
using TMS.api.Entities;
using TMS.api.Interfaces.Repositories;
using TMS.api.Interfaces.Services;
using TMS.api.Persistance;
using TMS.api.Shared.ExceptionMiddleware;
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
            var result = await _taskItemRepository.CreateTask(mappedEntity);
            await _unitOfWork.SaveChangesAsync();
            return new IdDto<Guid>
            {
                Id = result,
            };
        }

        public async Task<IdDto<Guid>> DeleteTaskAsync(Guid id)
        {
            var task = await _taskItemRepository.GetTaskByIdAsync(id);
            if(task == null || task.IsDeleted)
            {
                throw new BadRequestException($"Task item not found with id {id}");
            }
            task.IsDeleted = true;
            _taskItemRepository.UpdateTask(task);
            await _unitOfWork.SaveChangesAsync();
            return new IdDto<Guid> { Id = task.Id };
        }

        public async Task<TaskItemDto?> GetByIdAsync(Guid id)
        {
            var taskItem = await _taskItemRepository.GetTaskByIdAsync(id);
            if (taskItem == null)
            {
                throw new BadRequestException($"Task item not found with id {id}");
            }
            var dto = _mapper.Map<TaskItemDto>(taskItem);
            return dto;
        }

        public async Task<IList<TaskItemDto>> GetTasksAsync()
        {
            var result = await _taskItemRepository.GetTasksAsync();
            return _mapper.Map<IList<TaskItemDto>>(result);
        }

        public async Task<IdDto<Guid>> UpdateTaskItemAsync(TaskItemDto dto)
        {
            var taskItem = await _taskItemRepository.GetTaskByIdAsync(dto.Id.Value);
            if (taskItem == null)
            {
                throw new BadRequestException($"Task item not fount with id {dto.Id}");
            }

            taskItem.DueDate = dto.DueDate;
            taskItem.Status = dto.Status;
            taskItem.CtgryId = dto.CtgryId;
            taskItem.Title = dto.Title;
            taskItem.Description = dto.Description;
            taskItem.Priority = dto.Priority;
            taskItem.UpdatedAt = DateTime.UtcNow;

            _taskItemRepository.UpdateTask(taskItem);
            await _unitOfWork.SaveChangesAsync();
            return new IdDto<Guid> { Id = taskItem.Id };
        }
    }
}
