using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Application.Exceptions;
using TaskEntity = TaskingSystem.Domain.Entities.Task;
using DomainTaskStatus = TaskingSystem.Domain.Enums.TaskStatus;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
    {
        TaskEntity? task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);

        if (task is null)
        {
            throw new NotFoundException($"Task with ID {request.TaskId} was not found.");
        }

        task.Status = DomainTaskStatus.Completed;
        _taskRepository.Update(task);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}