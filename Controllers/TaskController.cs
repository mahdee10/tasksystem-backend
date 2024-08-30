using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSystemServer.Dtos.Event;
using TaskSystemServer.Dtos.Task;
using TaskSystemServer.Extentions;
using TaskSystemServer.Helpers;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTask(CreateTaskDto task)
        {
            var memberId = User.GetMemberId();
            var createdTask = await _taskRepo.CreateAsync(task.ToTaskFromCreate(int.Parse(memberId)));
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.TaskId }, createdTask.ToTaskDto());

        }

        [HttpGet("mytasks")]
        [Authorize]
        public async Task<IActionResult> GetTasks([FromQuery] QueryObject query)
        {
            var memberId = User.GetMemberId();
            var tasks = await _taskRepo.GetByIdAsync(int.Parse(memberId), query);
            return Ok(tasks.Select(t => t.ToTaskDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            var task = await _taskRepo.GetByTaskIdAsync(id);
            if (task == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(task.ToTaskDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var task = await _taskRepo.DeleteAsync(id);
            if (task == null)
            {
                return NotFound("Task does not exist");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] UpdateTaskDto task)
        {

            var taskModel = await _taskRepo.UpdateAsync(id, task);
            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel.ToTaskDto());

        }



    }
}
