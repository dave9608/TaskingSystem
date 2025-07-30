using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Application.Exceptions;
using TaskingSystem.Domain.Events;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public class AssignTaskCommandHandler : IRequestHandler<AssignTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublisher _publisher;

    public AssignTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IPublisher publisher)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _publisher = publisher;
    }

    public async Task Handle(AssignTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);

        if (task is null)
        {
            throw new NotFoundException($"Task with ID {request.TaskId} was not found.");
        }

        task.AssigneeId = request.AssigneeId;
        _taskRepository.Update(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new TaskAssignedEvent(task.Id, task.AssigneeId.Value), cancellationToken);
    }
}