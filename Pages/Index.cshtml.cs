using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Data;

namespace TodoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoContext _context;

        public List<TodoApp.Models.Task> Tasks { get; set; }

        public IndexModel(TodoContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Tasks = _context.Tasks.ToList(); // Load all tasks from the database
        }

        public IActionResult OnPostAddTask(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _context.Tasks.Add(new TodoApp.Models.Task { Name = name, IsDone = false });
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        public IActionResult OnPostMarkAsDone(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsDone = true;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}