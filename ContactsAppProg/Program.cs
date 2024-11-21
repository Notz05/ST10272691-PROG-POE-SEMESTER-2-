using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ContactsAppProg.Models;  // Import the namespace where ApplicationUser is defined
using Microsoft.AspNetCore.Identity;
using ContractsAppProg.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Context for Entity Framework (ensure connection string is set in appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity for authentication and roles (if you're using it for user authentication)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()  // Reference ApplicationUser here
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services for MVC (views and controllers)
builder.Services.AddControllersWithViews();

// Add session management if needed (optional but useful for storing role-based data)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set timeout duration
});

var app = builder.Build();

// Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();

// Use routing and authentication
app.UseRouting();
app.UseAuthentication();  // Ensure authentication middleware is added
app.UseAuthorization();   // Ensure authorization middleware is added
app.UseSession();  // To enable session usage, if needed

// Define routes (this is where your controllers and views are mapped)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
