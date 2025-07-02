using Microsoft.EntityFrameworkCore;
using TSAGroup_Tec.Interfaces;
using UserTask = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Repos;

/// <summary>
/// The TaskRepo class implements the ITaskRepo interface
/// </summary>
/// <param name="dbContext"></param>
public class TaskRepo(AppDbContext dbContext) : ITaskRepo
{
    /// <summary>
    /// The GetTasks method retrieves all tasks from the database.
    /// </summary>
    /// <returns>The full list of tasks</returns>
    public async Task<IEnumerable<UserTask>> GetTasks()
    {
        return await dbContext.Tasks.ToListAsync();
    }

    /// <summary>
    /// The GetTasksByUserId method retrieves tasks for a specific user.
    /// </summary>
    /// <param name="id">The ID of the task requested</param>
    /// <returns>The task that was requested</returns>
    public async Task<UserTask?> GetTaskById(int id)
    {
        return await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    /// <summary>
    /// The AddTask method adds a new task to the database.
    /// </summary>
    /// <param name="task">The task to be added</param>
    /// <returns>The result of the request</returns>
    public async Task<bool> AddTask(UserTask task)
    {
        dbContext.Tasks.Add(task);
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }

    /// <summary>
    /// The UpdateTask method updates an existing task in the database.
    /// </summary>
    /// <param name="task">The task to be updated along with the updated information</param>
    /// <returns>The result of the request</returns>
    public async Task<bool> UpdateTask(UserTask task)
    {
        var existingTask = dbContext.Tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null)
        {
            return false;
        }

        existingTask.Name = task.Name;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.CreatedAt = task.CreatedAt;
        existingTask.UpdatedAt = task.UpdatedAt;
        dbContext.Tasks.Update(existingTask);
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }

    /// <summary>
    /// The DeleteTask method removes a task from the database.
    /// </summary>
    /// <param name="id">The ID of the task to be deleted</param>
    /// <returns>The result of the request</returns>
    public async Task<bool> DeleteTask(int id)
    {
        var task = dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return false;
        }

        dbContext.Tasks.Remove(task);
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }
}