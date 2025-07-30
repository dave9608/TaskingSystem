using MediatR;

namespace TaskingSystem.Application.Features.Tasks.Commands;

public record CompleteTaskCommand(Guid TaskId) : IRequest;