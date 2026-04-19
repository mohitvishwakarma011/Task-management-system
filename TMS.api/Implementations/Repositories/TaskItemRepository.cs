using TMS.api.Entities;
using TMS.api.Interfaces.Repositories;
using TMS.api.Persistance;

namespace TMS.api.Implementations.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public TaskItemRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }
        public async Task<Guid> CreateTask(TaskItem taskItem)
        {
            var result = await _appDbContext.Tasks.AddAsync(taskItem);
            return taskItem.Id;
        }
    }
}
