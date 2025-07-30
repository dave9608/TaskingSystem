using MediatR;
using TaskingSystem.Application.Abstractions;
// Import our enum and give it a unique alias
using DomainTaskStatus = TaskingSystem.Domain.Enums.TaskStatus;
using TaskEntity = TaskingSystem.Domain.Entities.Task;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            // Use the alias here
            Status = DomainTaskStatus.ToDo
        };

        await _taskRepository.AddAsync(task, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}