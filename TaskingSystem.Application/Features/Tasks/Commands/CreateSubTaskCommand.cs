using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public record CreateSubTaskCommand(Guid ParentTaskId, string Title, string? Description) : IRequest<Guid>;