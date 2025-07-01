using TSAGroup_Tec.Models;
namespace TSAGroup_Tec.Repos;

public static class DbInit
{
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
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            },
            new Models.Task
            {
                Id = 2,
                Name = "Task 2",
                Description = "Description for Task 2",
                Status = "In Progress",
                CreatedAt = DateTime.UtcNow
            }
        );
        context.SaveChanges();
    }
}