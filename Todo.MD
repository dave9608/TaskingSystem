# **Project Development Checklist**
This document outlines the high-level steps taken to build the Tasking System backend.

## **Phase 1: Project Setup & Architecture**
[x] Create a blank Visual Studio solution.

[x] Set up a Clean Architecture project structure with four layers:

[x] TaskingSystem.Domain (Class Library)

[x] TaskingSystem.Application (Class Library)

[x] TaskingSystem.Infrastructure (Class Library)

[x] TaskingSystem.Api (ASP.NET Core Web API)

[x] Configure project references to enforce the dependency rule.

[x] Install necessary NuGet packages (ASP.NET Core, EF Core, MediatR, SQLite).

## **Phase 2: Core Feature Implementation**
[x] Define Domain Entities

[x] Create Task, User, and Comment entities.

[x] Create TaskStatus enum.

[x] Set up Persistence

[x] Create TaskingDbContext with DbSet for all entities.

[x] Implement ITaskRepository, IUserRepository, and ICommentRepository with their concrete implementations.

[x] Register repositories and DbContext for dependency injection.

[x] Create and apply initial database migrations.

[x] Implement Task Management Endpoints

[x] Create Task (POST)

[x] Get Task by ID (GET)

[x] Get All Tasks (GET)

[x] Assign Task (PUT)

[x] Complete Task (PUT)

[x] Implement User Management Endpoints

[x] Create User (POST)

[x] Get User by ID (GET)

[x] Get All Users (GET)

[x] Update User (PUT)

## **Phase 3: Advanced Features & Refinements**
[x] Implement Asynchronous Notifications

[x] Define TaskAssignedEvent.

[x] Publish event from AssignTaskCommandHandler.

[x] Create TaskAssignedEventHandler to call the notification service.

[x] Implement INotificationService using ILogger.

[x] Implement Sub-Task Functionality

[x] Add ParentTaskId to the Task entity.

[x] Create CreateSubTask command and handler.

[x] Add POST /api/tasks/{taskId}/subtasks endpoint.

[x] Update GetTaskByIdQueryHandler to include nested sub-tasks in the response.

[x] Implement Comments on Tasks

[x] Add AddCommentToTask command and handler.

[x] Add GetCommentsForTask query and handler.

[x] Add POST and GET endpoints for comments on a task.

[x] Implement Global Error Handling

[x] Create a custom NotFoundException.

[x] Implement and register a GlobalExceptionHandlingMiddleware.

[x] Update handlers to throw the custom exception.

[x] Refactor API Contracts

[x] Create request DTOs for all POST and PUT endpoints.

[x] Organize DTOs into a structured Contracts folder in the API project.

## **Phase 4: Documentation**
[x] Create a comprehensive README.md file.

[x] Explain the architecture and design patterns.

[x] Document all API endpoints.

[x] Provide a detailed project structure overview.

[x] Include setup and running instructions.

[x] Create this Todo.MD checklist.
