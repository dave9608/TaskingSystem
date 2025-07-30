using Microsoft.EntityFrameworkCore;
using TaskingSystem.Application.Abstractions;
using TaskEntity = TaskingSystem.Domain.Entities.Task;

namespace TaskingSystem.Infrastructure.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskingDbContext _dbContext;

        public TaskRepository(TaskingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Tasks.ToListAsync(cancellationToken);
        }

        public async Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task AddAsync(TaskEntity task, CancellationToken cancellationToken = default)
        {
            await _dbContext.Tasks.AddAsync(task, cancellationToken);
        }

        public void Update(TaskEntity task)
        {
            _dbContext.Tasks.Update(task);
        }
    }
}
