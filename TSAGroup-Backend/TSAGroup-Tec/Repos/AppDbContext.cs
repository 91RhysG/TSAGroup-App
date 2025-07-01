using Microsoft.EntityFrameworkCore;
using Task = TSAGroup_Tec.Models.Task;

namespace TSAGroup_Tec.Repos;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
}
