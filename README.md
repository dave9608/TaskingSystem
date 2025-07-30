# **Tasking System Backend**

This is a lightweight tasking system backend built with ASP.NET Core, following Clean Architecture. It offers endpoints to manage tasks and users, including sub-tasks and error handling.

PS - The comments endpoints were not part of the main spec, I just added it for myself to confirm testing everything works well with the backend, hence I have excluded them below.

## **Features**

### **Tasks**

* POST /api/tasks: Create a new main task.
* GET /api/tasks: List all tasks with assigned user names.
* GET /api/tasks/{taskId}: View a specific task's details.
* PUT /api/tasks/{taskId}/assign: Assign a task to a user.
* PUT /api/tasks/{taskId}/complete: Mark a task as complete.
* POST /api/tasks/{taskId}/subtasks: Add a sub-task to a parent task.
* Notifications: Sends async notifications when a task is assigned.

### **Users**

* POST /api/users: Create a new user.
* GET /api/users: List all users.
* GET /api/users/{userId}: View a specific user's details.
* PUT /api/users/{userId}: Update a user's name.

## **Architecture**

* Uses Clean Architecture for separation of concerns.
* CQRS Pattern with MediatR to split Commands (data changes) and Queries (data reads).
* Repository & Unit of Work Pattern for flexible data access.
* Domain Events with MediatR for async notifications.
* Global Exception Handling with custom middleware for standardized JSON errors (e.g., 404).

## **Project Structure**

* src/
  * TaskingSystem.Api/: Web API layer with controllers and middleware.
  * TaskingSystem.Application/: Business logic and use cases.
  * TaskingSystem.Domain/: Core entities and rules.
  * TaskingSystem.Infrastructure/: Database and service implementations.

## **Future Expansion**
* Authentication and Authorization: Securing our endpoints with token like JWT token to ensure only for example that an admin user can complete a task
* Input Validation: We can add some more improved input validation and cleaning/trimming the inputs to try and avoid invalid data.
* We can replace our current MediatR notifications with actual dedicated message que, something like RabbitMQ or maybe an email service that sends reminder emails.
* I would add some audit fields like created at, created by, last modified at

## **How to Run**

### **Prerequisites**

* .NET 8 SDK
* Visual Studio 2022

### **Setup**

* Open TaskingSystem.sln in Visual Studio.
* In Package Manager Console, set TaskingSystem.Infrastructure as the default project.
* Run "Update-Database" to set up the SQLite database.
* Set TaskingSystem.Api as the startup project.

### **Run**

* Press F5 or click Run in Visual Studio.
* Swagger UI will open to test the API.
