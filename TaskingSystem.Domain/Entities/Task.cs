using DomainTaskStatus = TaskingSystem.Domain.Enums.TaskStatus;

namespace TaskingSystem.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DomainTaskStatus Status { get; set; }

    public Guid? AssigneeId { get; set; }
    public Guid? ParentTaskId { get; set; }
}