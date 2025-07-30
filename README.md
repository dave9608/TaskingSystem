Tasking System Backend
A lightweight tasking system backend built with ASP.NET Core, adhering to Clean Architecture principles. It provides a comprehensive set of endpoints for managing tasks and users, including sub-task creation and robust error handling.
Features
Tasks

POST /api/tasks: Creates a new main task.
GET /api/tasks: Retrieves a list of all tasks, including the assigned user's name.
GET /api/tasks/{taskId}: Retrieves details of a specific task.
PUT /api/tasks/{taskId}/assign: Assigns a task to a user.
PUT /api/tasks/{taskId}/complete: Marks a task as complete.
POST /api/tasks/{taskId}/subtasks: Creates a new sub-task linked to a parent task.
Notifications: Triggers asynchronous background notifications when a task is assigned.

Users

POST /api/users: Creates a new user.
GET /api/users: Retrieves a list of all users.
GET /api/users/{userId}: Retrieves details of a specific user.
PUT /api/users/{userId}: Updates an existing user's name.

Architecture and Design
The solution follows Clean Architecture to ensure separation of concerns, testability, and maintainability.

CQRS Pattern: Utilizes the MediatR library to separate Commands (data modification) from Queries (data retrieval).
Repository & Unit of Work Pattern: Abstracts data access logic, enabling easy data source changes.
Domain Events: Leverages MediatR's notification system for asynchronous side effects like notifications.
Global Exception Handling: Custom middleware intercepts exceptions and returns standardized JSON error responses (e.g., 404 Not Found).

Project Structure
The solution is organized into four main projects, each with a distinct responsibility:

src/
TaskingSystem.Api/ (Presentation Layer: Exposes the application via a Web API)
Contracts/ (DTOs defining API request/response shapes)
Tasks/
Users/


Controllers/ (API controllers for endpoints)
TasksController.cs
UsersController.cs


Middleware/ (Custom middleware)
GlobalExceptionHandlingMiddleware.cs


Program.cs (Application entry point and DI configuration)


TaskingSystem.Application/ (Application Layer: Business logic and use cases)
Abstractions/ (Interfaces for data access and services)
ITaskRepository.cs
IUserRepository.cs
INotificationService.cs
IUnitOfWork.cs


Exceptions/ (Custom exceptions)
NotFoundException.cs


Features/ (Feature-specific logic)
Tasks/
Commands/ (Task modification use cases)
Queries/ (Task retrieval use cases)
EventHandlers/ (Asynchronous task event handlers)


Users/
Commands/ (User modification use cases)
Queries/ (User retrieval use cases)






TaskingSystem.Domain/ (Domain Layer: Core business entities and rules)
Entities/ (Core entities)
Task.cs
User.cs


Enums/ (Enumerations)
TaskStatus.cs


Events/ (Domain events)
TaskAssignedEvent.cs




TaskingSystem.Infrastructure/ (Infrastructure Layer: External concerns)
Persistence/ (Database-related implementations)
Migrations/ (EF Core migration files)
TaskingDbContext.cs (EF Core database context)
TaskRepository.cs (ITaskRepository implementation)
UserRepository.cs (IUserRepository implementation)


Services/ (External service implementations)
ConsoleNotificationService.cs (INotificationService implementation)







How to Run
Prerequisites

.NET 8 SDK
Visual Studio 2022

Setup

Open the TaskingSystem.sln file in Visual Studio.
Open the Package Manager Console (View > Other Windows > Package Manager Console).
Set the Default project dropdown to TaskingSystem.Infrastructure.
Run the command:Update-Database

This creates the SQLite database and its tables.
In Solution Explorer, right-click the TaskingSystem.Api project and select Set as Startup Project.

Run

Press F5 or click the Run button in Visual Studio.
The Swagger UI will open in your browser, allowing you to test all API endpoints.
