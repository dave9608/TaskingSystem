using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public record AssignTaskCommand(Guid TaskId, Guid AssigneeId) : IRequest;