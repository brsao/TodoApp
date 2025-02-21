namespace TodoApp.Models
{
    public class Task
    {
        public int Id { get; set; } // A unique number for each task
        public string Name { get; set; } // What the task is
        public bool IsDone { get; set; } // Is it finished?
    }
}