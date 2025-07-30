using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Application.Exceptions;

namespace TaskingSystem.Application.Features.Tasks.Queries;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskResponse?>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskResponse?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);

        if (task is null)
        {
            throw new NotFoundException($"Task with ID {request.TaskId} was not found.");
        }

        return new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString(),
            AssigneeId = task.AssigneeId
        };
    }
}