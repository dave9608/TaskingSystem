using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskingSystem.Api.Contracts.Users;
using TaskingSystem.Application.Features.Users.Commands;
using TaskingSystem.Application.Features.Users.Queries;

namespace TaskingSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand(request.Name);
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetUserById), new { userId = userId }, userId);
    }

    [HttpPut("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest request)
    {
        var command = new UpdateUserCommand(userId, request.Name);
        await _mediator.Send(command);
        return Ok(new { Message = "User has been updated successfully." });
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var users = await _mediator.Send(query);
        return Ok(users);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);
        return Ok(user);
    }
}