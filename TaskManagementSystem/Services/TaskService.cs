using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    // Purpose: Handles the "heavy lifting" and business rules.
    // Responsibility: Saving, updating, and deleting data while checking rules.
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        // Constructor: Sets up the database connection for the service.
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method: Gets all tasks from the database.
        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        // Method: Finds one specific task by its ID.
        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        // Method: Adds a new task.
        // Key Logic: Checks if the date is in the past.
        public async Task CreateTaskAsync(TaskItem task)
        {
            if (task.DueDate < DateTime.Now.Date)
            {
                throw new Exception("Due Date cannot be in the past");
            }
            _context.Add(task);
            await _context.SaveChangesAsync();
        }

        // Method: Updates an existing task.
        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }

        // Method: Removes a task from the database.
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}