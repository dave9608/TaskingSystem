using Microsoft.EntityFrameworkCore;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Domain.Entities;
using SystemTask = System.Threading.Tasks.Task;

namespace TaskingSystem.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly TaskingDbContext _dbContext;

    public UserRepository(TaskingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }

    public async SystemTask AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}