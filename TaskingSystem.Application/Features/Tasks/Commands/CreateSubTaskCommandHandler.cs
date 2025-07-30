using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Application.Exceptions;
using TaskingSystem.Domain.Enums;
using TaskEntity = TaskingSystem.Domain.Entities.Task;
using DomainTaskStatus = TaskingSystem.Domain.Enums.TaskStatus;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public class CreateSubTaskCommandHandler : IRequestHandler<CreateSubTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateSubTaskCommand request, CancellationToken cancellationToken)
    {
        var parentTask = await _taskRepository.GetByIdAsync(request.ParentTaskId, cancellationToken);
        if (parentTask is null)
        {
            throw new NotFoundException($"Parent task with ID {request.ParentTaskId} was not found.");
        }

        var subTask = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Status = DomainTaskStatus.ToDo,
            ParentTaskId = request.ParentTaskId
        };

        await _taskRepository.AddAsync(subTask, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subTask.Id;
    }
}