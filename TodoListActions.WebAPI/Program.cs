using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using TodoListActions.Application;
using TodoListActions.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddSingleton<IValidateOptions<DbOptions>, DbOptions>()
    .AddOptions<DbOptions>()
    .Bind(builder.Configuration.GetSection(DbOptions.Db))
    .ValidateOnStart();
builder.Services.AddSingleton<ConnectionFactory>();
builder.Services.AddSingleton<TodoListActions.Infrastructure.TaskFactory>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
