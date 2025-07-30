using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskingSystem.Api.Contracts.Tasks;
using TaskingSystem.Application.Features.Tasks.Commands;
using TaskingSystem.Application.Features.Tasks.Queries;

namespace TaskingSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var command = new CreateTaskCommand(request.Title, request.Description);
        var taskId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTask), new { taskId = taskId }, taskId);
    }

    [HttpGet("{taskId}")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTask(Guid taskId)
    {
        var query = new GetTaskByIdQuery(taskId);
        var task = await _mediator.Send(query);
        return Ok(task);
    }

    [HttpPut("{taskId}/assign")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignTask(Guid taskId, [FromBody] AssignTaskRequest request)
    {
        var command = new AssignTaskCommand(taskId, request.UserId);
        await _mediator.Send(command);
        return Ok(new { Message = "Task has been assigned successfully." });
    }

    [HttpPut("{taskId}/complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CompleteTask(Guid taskId)
    {
        var command = new CompleteTaskCommand(taskId);
        await _mediator.Send(command);
        return Ok(new { Message = "Task has been successfully marked as complete." });
    }

    [HttpPost("{taskId}/subtasks")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateSubTask(Guid taskId, [FromBody] CreateSubTaskRequest request)
    {
        var command = new CreateSubTaskCommand(taskId, request.Title, request.Description);
        var subTaskId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTask), new { taskId = subTaskId }, subTaskId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<TaskResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllTasks()
    {
        var query = new GetAllTasksQuery();
        var tasks = await _mediator.Send(query);
        return Ok(tasks);
    }
}