using MediatR;

namespace TaskingSystem.Application.Features.Users.Commands;

public record UpdateUserCommand(Guid UserId, string Name) : IRequest;