using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Domain.Entities;

namespace TaskingSystem.Application.Features.Users.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        // Map the User entities to a list of UserResponse DTOs
        var response = users.Select(user => new UserResponse
        {
            Id = user.Id,
            Name = user.Name
        }).ToList();

        return response;
    }
}