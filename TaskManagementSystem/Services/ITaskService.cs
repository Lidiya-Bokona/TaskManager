using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    // Purpose: A blueprint for what the Task Service can do.
    // Responsibility: Lists the methods available for managing tasks.
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}