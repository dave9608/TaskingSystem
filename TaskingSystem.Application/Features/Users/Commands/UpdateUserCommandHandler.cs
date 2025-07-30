using MediatR;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Application.Exceptions;

namespace TaskingSystem.Application.Features.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException($"User with ID {request.UserId} was not found.");
        }

        user.Name = request.Name;
        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}