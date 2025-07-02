using TSAGroup_Tec.Interfaces;
using UserTask = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Services;

/// <summary>
/// The TaskService class implements the ITaskService interface and provides methods to manage tasks.
/// </summary>
/// <param name="taskRepo"></param>
public class TaskService(ITaskRepo taskRepo) : ITaskService
{
    /// <summary>
    /// The GetTasks method retrieves all tasks from the repository.
    /// </summary>
    /// <returns>The full list of tasks</returns>
    public async Task<IEnumerable<UserTask>> GetTasks()
    {
        return await taskRepo.GetTasks();
    }

    /// <summary>
    /// The GetTaskById method retrieves a specific task by its ID from the repository.
    /// </summary>
    /// <param name="id">The id of the requested task</param>
    /// <returns>The requested task</returns>
    public async Task<UserTask?> GetTaskById(int id)
    {
        return await taskRepo.GetTaskById(id);
    }

    /// <summary>
    /// The AddTask method adds a new task to the repository.
    /// </summary>
    /// <param name="task">The task to be added</param>
    /// <returns>The result of the task being added</returns>
    public async Task<bool> AddTask(UserTask task)
    {
        return await taskRepo.AddTask(task);
    }

    /// <summary>
    /// The UpdateTask method updates an existing task in the repository.
    /// </summary>
    /// <param name="task">The task to be updated with updated information</param>
    /// <returns>The result of the request</returns>
    public async Task<bool> UpdateTask(UserTask task)
    {
        return await taskRepo.UpdateTask(task);
    }

    /// <summary>
    /// The DeleteTask method deletes a task from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the task to be deleted</param>
    /// <returns>The result of the request</returns>
    public async Task<bool> DeleteTask(int id)
    {
        return await taskRepo.DeleteTask(id);
    }
}