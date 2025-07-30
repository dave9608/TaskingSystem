using Microsoft.EntityFrameworkCore;
using TaskingSystem.Domain.Entities;
// Use an alias here to avoid ambiguity with System.Threading.Tasks.Task
using Task = TaskingSystem.Domain.Entities.Task;

namespace TaskingSystem.Infrastructure.Persistence;

public class TaskingDbContext : DbContext
{
    public TaskingDbContext(DbContextOptions<TaskingDbContext> options) : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}