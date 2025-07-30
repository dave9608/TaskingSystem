using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Queries;

public record GetAllTasksQuery() : IRequest<List<TaskResponse>>;