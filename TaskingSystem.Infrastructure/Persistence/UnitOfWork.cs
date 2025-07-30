using TaskingSystem.Application.Abstractions;

namespace TaskingSystem.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly TaskingDbContext _dbContext;

    public UnitOfWork(TaskingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}