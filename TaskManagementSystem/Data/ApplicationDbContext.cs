using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    /// <summary>
    /// Purpose: Manages the connection to the SQL database.
    /// Responsibility: It creates the "Tasks" table in the database.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        // Constructor: Initializes the database connection settings.
        // Why: Required to pass the connection string from appsettings.json.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Property: Represents the Tasks table.
        // What: It stores our TaskItem objects as rows in a table.
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
