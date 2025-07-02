using TaskStatus = TSAGroup_Tec.Enums.TaskStatus;

namespace TSAGroup_Tec.Repos;

/// <summary>
/// The DbInit class is responsible for initializing the database with seed data.
/// </summary>
public static class DbInit
{
    /// <summary>
    /// The SeedData method checks if the database is created and if there are any existing tasks.
    /// </summary>
    /// <param name="context">The connection to the database</param>
    public static void SeedData(AppDbContext context)
    {
        if (!context.Database.EnsureCreated()) return;
        if (context.Tasks.Any()) return;
        context.Tasks.AddRange(
            new Models.Task
            {
                Id = 1,
                Name = "Task 1",
                Description = "Description for Task 1",
                Status = TaskStatus.Deleted,
                CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(15),
                UpdatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 2,
                Name = "Task 2",
                Description = "Description for Task 2",
                Status = TaskStatus.InProgress,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 3,
                Name = "Task 3",
                Description = "Description for Task 3",
                Status = TaskStatus.Completed,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 4,
                Name = "Task 4",
                Description = "Description for Task 4",
                Status = TaskStatus.Deleted,
                CreatedAt = new DateTime(2025, 11, 4, 8, 14, 44, DateTimeKind.Utc),
                UpdatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 5,
                Name = "Task 5",
                Description = "Description for Task 5",
                Status = TaskStatus.OnHold,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 6,
                Name = "Task 6",
                Description = "Description for Task 6",
                Status = TaskStatus.Deleted,
                CreatedAt = new DateTime(2022, 5, 1, 12, 0, 44, DateTimeKind.Utc),
                UpdatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 7,
                Name = "Task 7",
                Description = "Description for Task 7",
                Status = TaskStatus.InProgress,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 8,
                Name = "Task 8",
                Description = "Description for Task 8",
                Status = TaskStatus.Completed,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 9,
                Name = "Task 9",
                Description = "Description for Task 9",
                Status = TaskStatus.NotStarted,
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 10,
                Name = "Task 10",
                Description = "Description for Task 10",
                Status = TaskStatus.OnHold,
                CreatedAt = DateTime.UtcNow
            }
        );
        context.SaveChanges();
    }
}