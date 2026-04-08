using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    // Purpose: The Waiter of the app. It takes web requests.
    // Responsibility: Calls the Service and returns the correct View.
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        // Constructor: Injects the TaskService so we can use it.
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Method: Shows the list of all tasks.
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return View(tasks);
        }

        // Method: Shows the "Create Task" page.
        public IActionResult Create()
        {
            return View();
        }

        // Method: Handles the "Save" button for a new task.
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _taskService.CreateTaskAsync(task);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DueDate", ex.Message);
                }
            }
            return View(task);
        }

        // Method: Shows the "Edit" page for a specific task.
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return View(task);
        }

        // Method: Handles the "Save" button for editing a task.
        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                await _taskService.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // Method: Marks a task as "Completed" immediately.
        public async Task<IActionResult> MarkCompleted(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task != null)
            {
                task.Status = "Completed";
                await _taskService.UpdateTaskAsync(task);
            }
            return RedirectToAction(nameof(Index));
        }

        // Method: Shows the "Are you sure you want to delete?" page.
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return View(task);
        }

        // Method: Actually deletes the task after confirmation.
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}