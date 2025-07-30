using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingSystem.Application.Abstractions
{
    public interface INotificationService
    {
        Task SendTaskAssignedNotificationAsync(Guid userId, string taskTitle, CancellationToken cancellationToken = default);
    }
}
