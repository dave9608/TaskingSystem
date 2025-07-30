// Use an alias here to avoid ambiguity with System.Threading.Tasks.Task
using TaskEntity = TaskingSystem.Domain.Entities.Task;

namespace TaskingSystem.Application.Abstractions
{
    public interface ITaskRepository
    {
        Task<TaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<TaskEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(TaskEntity task, CancellationToken cancellationToken = default);
        void Update(TaskEntity task);
    }
}
