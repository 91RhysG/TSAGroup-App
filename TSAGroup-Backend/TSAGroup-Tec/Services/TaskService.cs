using TSAGroup_Tec.Interfaces;
using UserTask = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Services;

public class TaskService(ITaskRepo taskRepo) : ITaskService
{
    public async Task<IEnumerable<UserTask>> GetTasks()
    {
        return await taskRepo.GetTasks();
    }

    public async Task<UserTask?> GetTaskById(int id)
    {
        return await taskRepo.GetTaskById(id);
    }

    public async Task<bool> AddTask(UserTask task)
    {
        return await taskRepo.AddTask(task);
    }

    public async Task<bool> UpdateTask(UserTask task)
    {
        return await taskRepo.UpdateTask(task);
    }

    public async Task<bool> DeleteTask(int id)
    {
        return await taskRepo.DeleteTask(id);
    }
}