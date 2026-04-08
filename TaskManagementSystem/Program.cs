using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Services;

// Purpose: This starts the builder that puts all the pieces of our app together.
var builder = WebApplication.CreateBuilder(args);

// --- SERVICE REGISTRATION ---

// Method: AddControllersWithViews()
// Purpose: Turns on the MVC (Model-View-Controller) system.
// Why: This allows us to use our TaskController and show HTML pages to the user.
builder.Services.AddControllersWithViews();

// Method: AddDbContext
// Purpose: Tells the app how to connect to our SQL database.
// Input: Uses the "DefaultConnection" string from the appsettings.json file.
// Why: We need this so Entity Framework can save our tasks to a real database.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Method: AddScoped<ITaskService, TaskService>()
// Purpose: Registers our TaskService into the system.
// Why: This follows the boss's rule of putting business logic in a separate layer. 
// When the TaskController asks for "ITaskService", the app will give it the "TaskService" class.
builder.Services.AddScoped<ITaskService, TaskService>();


// Purpose: This builds the app so it is ready to run.
var app = builder.Build();

// --- CONFIGURE THE WEB REQUEST PIPELINE ---

// Purpose: Handles errors and security.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Purpose: Forces the app to use a secure connection (HTTPS).
app.UseHttpsRedirection();

// Purpose: Allows the app to use folders like wwwroot (where Bootstrap and CSS are).
app.UseStaticFiles();

// Purpose: Enables the app to understand web addresses (URLs).
app.UseRouting();

app.UseAuthorization();

// Method: MapControllerRoute
// Purpose: Tells the app which page to show first when it starts up.
// Key Logic: We changed 'Home' to 'Task' so the To-Do list is the first thing you see.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

// Purpose: This actually starts the website!
app.Run();