using MediatR;

namespace TaskingSystem.Application.Features.Users.Commands;

public record CreateUserCommand(string Name) : IRequest<Guid>;