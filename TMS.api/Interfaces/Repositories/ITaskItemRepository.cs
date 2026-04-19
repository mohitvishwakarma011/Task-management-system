using TMS.api.DataTransferObjects;
using TMS.api.Entities;

namespace TMS.api.Interfaces.Repositories
{
    public interface ITaskItemRepository
    {
        Task<Guid> CreateTask(TaskItem taskItem);
        Task<TaskItem?> GetTaskByIdAsync(Guid id);
        Task<IList<TaskItem>> GetTasksAsync();
        void UpdateTask(TaskItem task);
    }
}
