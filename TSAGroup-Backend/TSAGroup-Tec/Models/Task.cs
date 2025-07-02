using TaskStatus = TSAGroup_Tec.Enums.TaskStatus;
namespace TSAGroup_Tec.Models;

/// <summary>
/// The Task class represents a task in the application.
/// </summary>
public record Task
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required TaskStatus Status { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null;
}