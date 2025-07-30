using MediatR;
using TaskingSystem.Application.Abstractions;

namespace TaskingSystem.Application.Features.Tasks.Queries;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskResponse>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<List<TaskResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync(cancellationToken);
        var users = await _userRepository.GetAllAsync(cancellationToken);

        // Create a dictionary for quick user lookups
        var userDictionary = users.ToDictionary(u => u.Id, u => u.Name);

        var response = tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString(),
            AssigneeId = task.AssigneeId,
            // Look up the user's name if the task is assigned
            AssigneeName = task.AssigneeId.HasValue && userDictionary.TryGetValue(task.AssigneeId.Value, out var name)
                ? name
                : null
        }).ToList();

        return response;
    }
}