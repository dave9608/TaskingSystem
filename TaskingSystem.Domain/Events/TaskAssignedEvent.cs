using MediatR;

namespace TaskingSystem.Domain.Events;

public record TaskAssignedEvent(Guid TaskId, Guid AssigneeId) : INotification;