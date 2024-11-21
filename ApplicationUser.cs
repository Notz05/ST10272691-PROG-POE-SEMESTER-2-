using Microsoft.AspNetCore.Identity;

namespace ContactsAppProg.Models
{
    // Inherit from IdentityUser to enable ASP.NET Core Identity functionality
    public class ApplicationUser : IdentityUser
    {
        // You can add additional properties like FirstName, LastName, etc.
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
