Project Report: Task Management System
What I Learned:
MVC Architecture: I learned how to separate data (Models), logic (Services), and the user interface (Views).
Dependency Injection: I learned how to register services in Program.cs and inject them into controllers to keep the code clean.
Repository/Service Pattern: I learned why business logic belongs in a Service layer instead of the Controller to make the app easier to maintain.
Entity Framework Core: I learned how to map C# classes to SQL database tables using migrations.
Data Annotations: I used attributes like [Required] to handle validation both on the server and in the UI.
Challenges Faced:
Separation of Concerns: It was a challenge at first to move logic out of the controller into the service layer, but it made the code much more readable.
Database Connection: Setting up the appsettings.json and managing SQL Server connections required careful attention to JSON syntax.
Environment Issues: I faced some challenges with the Package Manager Console not recognizing commands, which I solved by ensuring the correct NuGet packages were installed and the solution was properly focused.
