using TaskingSystem.Domain.Entities;
using SystemTask = System.Threading.Tasks.Task;

namespace TaskingSystem.Application.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
    SystemTask AddAsync(User user, CancellationToken cancellationToken = default);

    void Update(User user);
}