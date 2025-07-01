using Microsoft.EntityFrameworkCore;
using TSAGroup_Tec.Interfaces;
using UserTask = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Repos;

public class TaskRepo(AppDbContext dbContext) : ITaskRepo
{
    public async Task<IEnumerable<UserTask>> GetTasks()
    {
        return await dbContext.Tasks.ToListAsync();
    }

    public async Task<UserTask?> GetTaskById(int id)
    {
        return await dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> AddTask(UserTask task)
    {
        dbContext.Tasks.Add(task);
        var result = await dbContext.SaveChangesAsync();
        return result > 0;
    }

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