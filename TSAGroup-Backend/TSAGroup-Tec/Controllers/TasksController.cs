using Microsoft.AspNetCore.Mvc;
using TSAGroup_Tec.Interfaces;
using TaskModel = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Controllers;

/// <summary>
/// The TasksController is responsible for handling HTTP requests related to tasks.
/// </summary>
/// <param name="taskService"></param>
[ApiController]
[Route("api/[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    /// <summary>
    /// Gets the list of tasks from the service.
    /// </summary>
    /// <returns>The full list of tasks</returns>
    [HttpGet(Name = "GetTasks")]
    public async Task<ActionResult<List<Task>>> Get()
    {
        return Ok(await taskService.GetTasks());
    }

    /// <summary>
    /// Returns a specific task by its ID.
    /// </summary>
    /// <param name="id">The ID to be retrieved</param>
    /// <returns>The task requested</returns>
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

    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="task">The new task to be added</param>
    /// <returns>The result for the request</returns>
    [HttpPost(Name = "CreateTask")]
    public async Task<ActionResult<Task>> Post([FromBody] TaskModel task)
    {
        return await taskService.AddTask(task)
            ? CreatedAtRoute("GetTaskById", new { id = task.Id }, task)
            : BadRequest("Failed to add task");
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <param name="id">The ID of the task to be updated</param>
    /// <param name="updatedTask">The updated task</param>
    /// <returns>The result of the update</returns>
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

    /// <summary>
    /// The method to delete a task by its ID.
    /// </summary>
    /// <param name="id">The ID of the task to be deleted</param>
    /// <returns>The result of the request</returns>
    [HttpDelete("{id:int}", Name = "DeleteTask")]
    public async Task<ActionResult> Delete(int id)
    {
        return await taskService.DeleteTask(id) ? NoContent() : BadRequest("Failed to delete task");
    }
}