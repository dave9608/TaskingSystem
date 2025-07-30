using Microsoft.Extensions.Logging;
using TaskingSystem.Application.Abstractions;

namespace TaskingSystem.Infrastructure.Services;

public class ConsoleNotificationService : INotificationService
{
    private readonly ILogger<ConsoleNotificationService> _logger;

    public ConsoleNotificationService(ILogger<ConsoleNotificationService> logger)
    {
        _logger = logger;
    }

    public Task SendTaskAssignedNotificationAsync(Guid userId, string taskTitle, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[NOTIFICATION] Task '{TaskTitle}' has been assigned to user {UserId}.", taskTitle, userId);

        return Task.CompletedTask;
    }
}