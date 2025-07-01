using Microsoft.AspNetCore.Mvc;
using TSAGroup_Tec.Repos;

namespace TSAGroup_Tec.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;

    [HttpGet(Name = "GetTasks")]
    public ActionResult<List<Task>> Get()
    {
        var tasks = _dbContext.Tasks.ToList();
        return Ok(tasks);
    }
    
    [HttpGet("{id:int}", Name = "GetTaskById")]
    public ActionResult<Task> Get(int id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    
    [HttpPost(Name = "CreateTask")]
    public ActionResult<Task> Post([FromBody] TSAGroup_Tec.Models.Task task)
    {
        if (task == null)
        {
            return BadRequest("Task cannot be null");
        }
        
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
        
        return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);
    }
    
    [HttpPut("{id:int}", Name = "UpdateTask")]
    public ActionResult<Task> Put(int id, [FromBody] TSAGroup_Tec.Models.Task updatedTask)
    {
        if (updatedTask == null || updatedTask.Id != id)
        {
            return BadRequest("Invalid task data");
        }

        var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound();
        }

        existingTask.Name = updatedTask.Name;
        existingTask.Description = updatedTask.Description;
        existingTask.Status = updatedTask.Status;
        existingTask.CreatedAt = updatedTask.CreatedAt;

        _dbContext.SaveChanges();

        return Ok(existingTask);
    }
    
    [HttpDelete("{id:int}", Name = "DeleteTask")]
    public ActionResult Delete(int id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        _dbContext.Tasks.Remove(task);
        _dbContext.SaveChanges();

        return NoContent();
    }
}