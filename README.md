Tasking System Backend
This project is a lightweight tasking system backend built with ASP.NET Core, demonstrating the principles of Clean Architecture. It provides a full suite of endpoints for managing tasks and users, including creating sub-tasks and handling errors gracefully.
Features
Tasks

POST /api/tasks: Creates a new main task
GET /api/tasks: Retrieves a list of all tasks, including the assigned user's name
GET /api/tasks/{taskId}: Retrieves the details of a specific task
PUT /api/tasks/{taskId}/assign: Assigns a task to a user
PUT /api/tasks/{taskId}/complete: Marks a task as complete
POST /api/tasks/{taskId}/subtasks: Creates a new sub-task linked to a parent task
Notifications: Triggers an asynchronous background notification when a task is assigned

Users

POST /api/users: Creates a new user
GET /api/users: Retrieves a list of all users
GET /api/users/{userId}: Retrieves the details of a specific user
PUT /api/users/{userId}: Updates an existing user's name

Architecture and Design
The solution follows Clean Architecture to ensure a clear separation of concerns, making the system testable and maintainable.

CQRS Pattern: Uses the MediatR library to separate Commands (actions that change data) from Queries (actions that read data)
Repository & Unit of Work Pattern: Abstracts data access logic from the core application, allowing for easier changes to the data source
Domain Events: Uses MediatR's notification system to handle side effects like sending notifications asynchronously
Global Exception Handling: A custom middleware intercepts exceptions and formats clean, standardized JSON error responses (e.g., 404 Not Found)

Project Structure
The solution is organized into four main projects, each with a specific responsibility:
📁 TaskingSystem.Api (Presentation Layer)
Exposes the application via a Web API

Contracts/ - DTOs defining the shape of API request bodies

Tasks/
Users/


Controllers/

TasksController.cs - API controller for task-related endpoints
UsersController.cs - API controller for user-related endpoints


Middleware/

GlobalExceptionHandlingMiddleware.cs - Catches exceptions and formats error responses


Program.cs - Application entry point and service registration (DI)

📁 TaskingSystem.Application (Application Layer)
Contains all business logic and use cases

Abstractions/

ITaskRepository.cs - Contract for task data access
IUserRepository.cs - Contract for user data access
INotificationService.cs - Contract for sending notifications
IUnitOfWork.cs - Contract for saving changes to the database atomically


Exceptions/

NotFoundException.cs - Custom exception for "not found" scenarios


Features/

Tasks/

Commands/ - Use cases that modify task state
Queries/ - Use cases that read task state
EventHandlers/ - Handlers for asynchronous task events


Users/

Commands/ - Use cases that modify user state
Queries/ - Use cases that read user state





📁 TaskingSystem.Domain (Domain Layer)
Core business entities and rules. No dependencies

Entities/

Task.cs - The core Task entity, with sub-task support
User.cs - The User entity


Enums/

TaskStatus.cs - Enum for the state of a task


Events/

TaskAssignedEvent.cs - Event published when a task is assigned



📁 TaskingSystem.Infrastructure (Infrastructure Layer)
Implements external concerns

Persistence/

Migrations/ - EF Core database migration files
TaskingDbContext.cs - Entity Framework database context
TaskRepository.cs - Implementation of ITaskRepository
UserRepository.cs - Implementation of IUserRepository


Services/

ConsoleNotificationService.cs - Implementation of INotificationService



How to Run
Prerequisites

.NET 8 SDK
Visual Studio 2022

Setup

Open the TaskingSystem.sln file in Visual Studio
Open the Package Manager Console (View > Other Windows > Package Manager Console)
Set the Default project dropdown to TaskingSystem.Infrastructure and run the command:
Update-Database
This will create the SQLite database and its tables
In the Solution Explorer, right-click the TaskingSystem.Api project and select "Set as Startup Project"

Run

Press F5 or click the run button in Visual Studio
The Swagger UI will open in your browser, allowing you to test all the API endpoints

Technologies Used

ASP.NET Core 8
Entity Framework Core (with SQLite)
MediatR (for CQRS pattern)
Swagger/OpenAPI (for API documentation)
Clean Architecture principles

Database
The application uses SQLite as the database, which requires no additional setup and creates a local file-based database perfect for development and testing.