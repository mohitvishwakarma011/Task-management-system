using TMS.api.DataTransferObjects;

namespace TMS.api.Interfaces.Services
{
    public interface ITaskItemService
    {
        Task<IdDto<Guid>> CreateTaskItem(TaskItemDto dto);
        Task<TaskItemDto?> GetByIdAsync(Guid id);
        Task<IList<TaskItemDto>> GetTasksAsync(int categoryID);
        Task<IdDto<Guid>> UpdateTaskItemAsync(TaskItemDto dto);
        Task<IdDto<Guid>> DeleteTaskAsync(Guid id);
        Task<IdDto<Guid>> ChangeStatus(ChangeStatusDto statusDto);
    }
}
