using MediatR;

namespace TaskingSystem.Application.Features.Users.Queries;

public record GetAllUsersQuery() : IRequest<List<UserResponse>>;