using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactsAppProg.Models;

namespace ContactsAppProg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Display the login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Process the login form
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Role-based navigation
                switch (model.Role)
                {
                    case "Lecturer":
                        // Redirect to SubmitClaim for Lecturer
                        return RedirectToAction("SubmitClaim", "Claim");

                    case "HR":
                        // Redirect to TrackClaim for HR
                        return RedirectToAction("TrackClaim", "Claim");

                    case "ProgramCoordinator":
                        // Redirect to TrackClaim for Program Coordinator
                        return RedirectToAction("TrackClaim", "Claim");

                    default:
                        ModelState.AddModelError("", "Invalid role selected.");
                        break;
                }
            }

            // Return to the login view with validation errors
            return View(model);
        }

        // Home page (Index)
        public IActionResult Index()
        {
            return View();
        }

        // Privacy page (if needed)
        public IActionResult Privacy()
        {
            return View();
        }

        // Error handling page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
