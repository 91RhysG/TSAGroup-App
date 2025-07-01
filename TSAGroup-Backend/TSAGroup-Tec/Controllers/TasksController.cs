using Microsoft.AspNetCore.Mvc;
using TSAGroup_Tec.Interfaces;
using TaskModel = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpGet(Name = "GetTasks")]
    public async Task<ActionResult<List<Task>>> Get()
    {
        return Ok(await taskService.GetTasks());
    }

    [HttpGet("{id:int}", Name = "GetTaskById")]
    public async Task<ActionResult<Task>> Get(int id)
    {
        var task = await taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost(Name = "CreateTask")]
    public async Task<ActionResult<Task>> Post([FromBody] TaskModel task)
    {
        return await taskService.AddTask(task)
            ? CreatedAtRoute("GetTaskById", new { id = task.Id }, task)
            : BadRequest("Failed to add task");
    }

    [HttpPut("{id:int}", Name = "UpdateTask")]
    public async Task<ActionResult<Task>> Put(int id, [FromBody] TaskModel updatedTask)
    {
        if (updatedTask.Id != id)
        {
            return BadRequest("Invalid task data");
        }

        return await taskService.UpdateTask(updatedTask)
            ? Ok(updatedTask)
            : BadRequest("Failed to update task");
    }

    [HttpDelete("{id:int}", Name = "DeleteTask")]
    public async Task<ActionResult> Delete(int id)
    {
        return await taskService.DeleteTask(id) ? NoContent() : BadRequest("Failed to delete task");
    }
}