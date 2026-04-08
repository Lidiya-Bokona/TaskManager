using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    // Purpose: A list of rules for what our TaskService MUST do.
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(string searchString);
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}
