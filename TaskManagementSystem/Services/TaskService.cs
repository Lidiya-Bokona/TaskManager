using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    /// <summary>
    /// Purpose: Handles all the business logic and database work.
    /// Responsibility: It keeps the Controller "thin" by doing the heavy lifting here.
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        // Constructor: Connects the database to this service.
        public TaskService(ApplicationDbContext context) { _context = context; }

        // Method: Gets all tasks, and can search by title.
        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(string searchString)
        {
            var tasks = _context.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
                tasks = tasks.Where(t => t.Title.Contains(searchString));
            return await tasks.ToListAsync();
        }

        // Method: Finds a task using its ID.
        public async Task<TaskItem> GetTaskByIdAsync(int id) => await _context.Tasks.FindAsync(id);

        // Method: Saves a new task.
        // Business Rule: Checks if the date is in the past!
        public async Task CreateTaskAsync(TaskItem task)
        {
            if (task.DueDate < DateTime.Now.Date) 
                throw new Exception("You can't set a deadline in the past, time traveler!");
            _context.Add(task);
            await _context.SaveChangesAsync();
        }

        // Method: Updates a task that already exists.
        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }

        // Method: Deletes a task forever.
        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null) { _context.Tasks.Remove(task); await _context.SaveChangesAsync(); }
        }
    }
}
