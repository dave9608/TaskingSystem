using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Queries;

public record GetTaskByIdQuery(Guid TaskId) : IRequest<TaskResponse?>;