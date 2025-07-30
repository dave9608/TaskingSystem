namespace TaskingSystem.Application.Features.Tasks.Queries;

public class TaskResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public Guid? AssigneeId { get; set; }
    public string? AssigneeName { get; set; }
}