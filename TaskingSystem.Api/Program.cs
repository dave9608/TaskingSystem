using Microsoft.EntityFrameworkCore;
using TaskingSystem.Api.Middleware;
using TaskingSystem.Application.Abstractions;
using TaskingSystem.Infrastructure.Persistence;
using TaskingSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// =================================================================
// Add services to the container.
// =================================================================

// Application Services
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(TaskingSystem.Application.AssemblyReference.Assembly));

// Infrastructure Services
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationService, ConsoleNotificationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Database Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskingDbContext>(options =>
    options.UseSqlite(connectionString));

// API Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Middleware Services
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();


var app = builder.Build();

// =================================================================
// Configure the HTTP request pipeline.
// =================================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom middleware for global exception handling
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();