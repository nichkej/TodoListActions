using Microsoft.AspNetCore.Mvc;
using TodoListActions.Application;
using Doman = TodoListActions.Domain;

namespace TodoListActions.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            return Ok(await _taskService.GetAllTasks());
        }

        [HttpGet("id={id}")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            return Ok(await _taskService.GetTaskById(id));
        }
    }
}
