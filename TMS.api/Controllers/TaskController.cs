using Microsoft.AspNetCore.Mvc;
using TMS.api.DataTransferObjects;
using TMS.api.Implementations.Services;
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
    }
}
