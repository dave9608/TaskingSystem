using MediatR;

namespace TaskingSystem.Application.Features.Users.Queries;

public record GetUserByIdQuery(Guid UserId) : IRequest<UserResponse>;