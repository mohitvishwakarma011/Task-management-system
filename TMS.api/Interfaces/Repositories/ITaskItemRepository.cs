using TMS.api.Entities;

namespace TMS.api.Interfaces.Repositories
{
    public interface ITaskItemRepository
    {
        Task<Guid> CreateTask(TaskItem taskItem);
    }
}
