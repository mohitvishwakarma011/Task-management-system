using TMS.api.DataTransferObjects;

namespace TMS.api.Interfaces.Services
{
    public interface ITaskItemService
    {
        Task<IdDto<Guid>> CreateTaskItem(TaskItemDto dto);
    }
}
