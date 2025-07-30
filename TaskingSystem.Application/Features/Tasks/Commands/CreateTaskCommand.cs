using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public record CreateTaskCommand(string Title, string? Description) : IRequest<Guid>;