using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    /// <summary>
    /// Purpose: This class is the data blueprint for a single Task.
    /// Responsibility: It tells the app and the database what information to store.
    /// Interacts with: The Database, the TaskService, and the Views.
    /// </summary>
    public class TaskItem
    {
        // Purpose: Unique ID number for the database.
        // Why: Every task needs its own "ID badge" so we can find it later.
        [Key]
        public int Id { get; set; }

        // Purpose: The name of the task.
        // Why: Required because you can't have a task without a name!
        [Required(ErrorMessage = "Yo, you gotta give the task a title!")]
        public string Title { get; set; }

        // Purpose: Extra details about the task.
        // Why: This is optional, sometimes you don't need a description.
        public string? Description { get; set; }

        // Purpose: When the task is due.
        // Why: Required so we don't miss our deadlines.
        [Required(ErrorMessage = "Don't forget the date!")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        // Purpose: Current progress of the task.
        // Why: Defaults to "Pending" because new tasks aren't done yet.
        public string Status { get; set; } = "Pending";
    }
}
