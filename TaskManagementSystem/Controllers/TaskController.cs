using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    /// <summary>
    /// Purpose: Handles web requests from the user.
    /// Responsibility: It's a "Thin Layer"—it just calls the Service and returns a View.
    /// </summary>
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        // Constructor: Injects the Service into the Controller.
        public TaskController(ITaskService service) { _service = service; }

        // Method: Shows the list of tasks.
        public async Task<IActionResult> Index(string searchString) => View(await _service.GetAllTasksAsync(searchString));

        // Method: Shows the empty "Create" form.
        public IActionResult Create() => View();

        // Method: Receives the new task data and tells the service to save it.
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                try {
                    await _service.CreateTaskAsync(task);
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex) {
                    ModelState.AddModelError("DueDate", ex.Message);
                }
            }
            return View(task);
        }

        // Method: Shows the "Edit" form.
        public async Task<IActionResult> Edit(int id) => View(await _service.GetTaskByIdAsync(id));

        // Method: Saves the edited changes.
        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            if (ModelState.IsValid) { await _service.UpdateTaskAsync(task); return RedirectToAction(nameof(Index)); }
            return View(task);
        }

        // Method: Shows the scary "Delete Confirmation" page.
        public async Task<IActionResult> Delete(int id) => View(await _service.GetTaskByIdAsync(id));

        // Method: Actually deletes it after the user says "Yes."
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteTaskAsync(id); return RedirectToAction(nameof(Index)); }

        // Method: Shortcut to mark a task done.
        public async Task<IActionResult> Complete(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            task.Status = "Completed";
            await _service.UpdateTaskAsync(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
