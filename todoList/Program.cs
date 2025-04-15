using Microsoft.EntityFrameworkCore;
using todoList;

var builder = WebApplication.CreateBuilder(args);

// add services (DI)
builder.Services.AddDbContext<TodoDb>(options => options.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// use and map methods
app.MapGet("/todos", async (TodoDb todoDb) =>
{
    return await todoDb.Todos.ToListAsync();
});

app.MapGet("/todos/{id}", async (int id, TodoDb todoDb) =>
{
    return await todoDb.Todos.FindAsync(id);
});

app.MapPut("/todos/{id}", async (int id, TodoItem inputTodo, TodoDb todoDb) =>
{
    var todo = await todoDb.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsActive = inputTodo.IsActive;

    await todoDb.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPost("/todos", async (TodoItem inputTodo, TodoDb todoDb) =>
{
    todoDb.Add(inputTodo);
    await todoDb.SaveChangesAsync();
    return Results.Created($"/todos/{inputTodo.Id}", inputTodo);    
});

app.MapDelete("/todos/{id}", async (int id, TodoDb todoDb) =>
{
    if (await todoDb.Todos.FindAsync(id) is TodoItem todo)
    {
        todoDb.Remove(todo);
        await todoDb.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.Run();
