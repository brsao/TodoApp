using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoContext : DbContext
    {
        // Add a constructor that accepts DbContextOptions<TodoContext>
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<Models.Task> Tasks { get; set; } // A list of all tasks

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=tasks.db"); // Use SQLite to store tasks
        }
    }
}