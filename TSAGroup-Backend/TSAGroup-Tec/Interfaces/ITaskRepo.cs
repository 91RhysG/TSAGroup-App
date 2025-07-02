using UserTask = TSAGroup_Tec.Models.Task;
namespace TSAGroup_Tec.Interfaces;

/// <summary>
/// The ITaskRepo interface defines the contract for task repository operations.
/// </summary>
public interface ITaskRepo
{
    Task<IEnumerable<UserTask>> GetTasks();
    Task<UserTask?> GetTaskById(int id);
   Task<bool> AddTask(UserTask task);
    Task<bool> UpdateTask(UserTask task);
    Task<bool> DeleteTask(int id);
}