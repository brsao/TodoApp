using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the database context with SQLite
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

var app = builder.Build();

// Seed the database with some tasks
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
    context.Database.EnsureCreated();

    if (!context.Tasks.Any())
    {
        context.Tasks.AddRange(
            new TodoApp.Models.Task { Name = "Brush teeth", IsDone = false },
            new TodoApp.Models.Task { Name = "Feed the cat", IsDone = true },
            new TodoApp.Models.Task { Name = "Learn ASP.NET Core", IsDone = false }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages(); // Ensure this line is present

app.Run();