using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    // Purpose: This class defines what a Task looks like in our app.
    // Responsibility: It holds the data for Title, Description, Date, and Status.
    // Interactions: It is used by the Database, the Service, and the Views.
    public class TaskItem
    {
        // Purpose: Unique ID for the database.
        // Why: The database needs a primary key to find specific tasks.
        [Key]
        public int Id { get; set; }

        // Purpose: The name of the task.
        // Why: Required so the user knows what the task is.
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        // Purpose: Extra details about the task.
        // Why: Optional, so the user can add more info if they want.
        public string? Description { get; set; }

        // Purpose: When the task needs to be done.
        // Why: Required to help users track deadlines.
        [Required(ErrorMessage = "Due Date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        // Purpose: Tells us if the task is finished.
        // Why: Helps filter and track progress. Default is "Pending".
        public string Status { get; set; } = "Pending";
    }
}