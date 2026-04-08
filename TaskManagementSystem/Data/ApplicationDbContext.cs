using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    // Purpose: This class manages the connection to the SQL database.
    // Responsibility: It tells Entity Framework which models should be tables.
    public class ApplicationDbContext : DbContext
    {
        // Constructor: Initializes the database options.
        // Input: DbContextOptions (database settings like the connection string).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Property: The collection of Tasks.
        // Why: This creates the "Tasks" table in our database.
        public DbSet<TaskItem> Tasks { get; set; }
    }
}