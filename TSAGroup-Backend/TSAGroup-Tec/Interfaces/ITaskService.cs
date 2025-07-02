using UserTask = TSAGroup_Tec.Models.Task;
namespace TSAGroup_Tec.Interfaces;

/// <summary>
/// The ITaskService interface defines the contract for task management services.
/// </summary>
public interface ITaskService
{
    Task<IEnumerable<UserTask>> GetTasks();
    Task<UserTask?> GetTaskById(int id);
    Task<bool> AddTask(UserTask task);
    Task<bool> UpdateTask(UserTask task);
    Task<bool> DeleteTask(int id);
}