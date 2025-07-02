using Microsoft.EntityFrameworkCore;
using Task = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Repos;

/// <summary>
/// The AppDbContext class represents the database context for the application.
/// </summary>
/// <param name="options"></param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
}
