using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Domain.Events;

namespace TaskingSystem.Application.Features.Tasks.EventHandlers;

public class TaskAssignedEventHandler : INotificationHandler<TaskAssignedEvent>
{
    private readonly INotificationService _notificationService;
    private readonly ITaskRepository _taskRepository;

    public TaskAssignedEventHandler(INotificationService notificationService, ITaskRepository taskRepository)
    {
        _notificationService = notificationService;
        _taskRepository = taskRepository;
    }

    public async Task Handle(TaskAssignedEvent notification, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(notification.TaskId, cancellationToken);
        if (task is null) return;

        await _notificationService.SendTaskAssignedNotificationAsync(notification.AssigneeId, task.Title, cancellationToken);
    }
}