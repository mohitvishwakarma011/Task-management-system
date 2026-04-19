using Microsoft.EntityFrameworkCore;
using TMS.api.DataTransferObjects;
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

        public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return await _appDbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<IList<TaskItem>> GetTasksAsync()
        {
            return await _appDbContext.Tasks.Where(t => !t.IsDeleted).ToListAsync();
        }

        public void UpdateTask(TaskItem task)
        {
            _appDbContext.Tasks.Update(task);
        }
    }
}
