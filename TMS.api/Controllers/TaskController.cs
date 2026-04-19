using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TMS.api.DataTransferObjects;
using TMS.api.Interfaces.Services;

namespace TMS.api.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TaskController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItemDto dto)
        {
            return Ok(await _taskItemService.CreateTaskItem(dto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById([FromRoute] Guid id)
        {
            return Ok(await _taskItemService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery]int categoryID)
        {
            return Ok(await _taskItemService.GetTasksAsync(categoryID));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskItemDto dto)
        {
            return Ok(await _taskItemService.UpdateTaskItemAsync(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
        {
            return Ok(await _taskItemService.DeleteTaskAsync(id));
        }

        [HttpPost("change-status")]
        [ProducesResponseType(typeof(IdDto<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusDto dto)
        {
            return Ok(await _taskItemService.ChangeStatus(dto));
        }
    }
}
