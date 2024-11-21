using Microsoft.AspNetCore.Mvc;
using ContractsAppProg.Models;

public class AccountController : Controller
{
    // Display the login page
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Handle the form submission
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Set the user's role and redirect them to their specific page
            // This can be updated to fit your authentication mechanism
            if (model.Role == "HR")
            {
                return RedirectToAction("Index", "HR");
            }
            else if (model.Role == "Lecturer")
            {
                return RedirectToAction("Index", "Lecturer");
            }
            else if (model.Role == "ProgramCoordinator")
            {
                return RedirectToAction("Index", "ProgramCoordinator");
            }
        }

        // If validation fails, show the login page again
        return View();
    }
}
