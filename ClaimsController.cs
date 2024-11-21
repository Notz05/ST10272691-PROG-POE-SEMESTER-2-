using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ContractsAppProg.Models;
using ContractsAppProg.Data;
using ContactsAppProg.Models;

namespace ContractsAppProg.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor to inject the ApplicationDbContext
        public ClaimController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST action for submitting a claim with file upload
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(SubmitClaimViewModel model, IFormFile SupportingDocument)
        {
            // Ensure the model is valid
            if (ModelState.IsValid)
            {
                string filePath = null;

                // Check if a file was uploaded
                if (SupportingDocument != null && SupportingDocument.Length > 0)
                {
                    // Get the file path for saving the uploaded file
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", SupportingDocument.FileName);

                    // Save the file asynchronously
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await SupportingDocument.CopyToAsync(stream);
                    }
                }

                // Create a new claim instance
                var newClaim = new Claim
                {
                    LecturerName = model.LecturerName,
                    LecturerEmail = model.LecturerEmail,
                    //LecturerID = model.LecturerID,
                    HoursWorked = model.HoursWorked,
                    HourlyRate = (double)model.HourlyRate, // Ensure the model's HourlyRate is correctly used
                    AdditionalNotes = model.AdditionalNotes,
                    SupportingDocumentPath = filePath, // Store the file path
                    Status = "Pending" // Default status is "Pending"
                };

                // Add the new claim to the database
                _dbContext.Claims.Add(newClaim);
                await _dbContext.SaveChangesAsync();

                // Redirect to the Index page after successfully saving the claim
                return RedirectToAction("Index", "Home");
            }

            // If model is invalid, return to the form with validation errors
            return View(model);
        }

        // GET action for displaying the claim submission form
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // GET action for displaying the tracked claims based on lecturer ID
        public IActionResult TrackClaim(int lecturerId)
        {
            var claims = _dbContext.Claims.Where(c => c.LecturerID == lecturerId).ToList(); // Filter by lecturer ID
            return View(claims); // Pass the filtered claims to the view
        }

        // GET action for displaying pending claims
        public IActionResult PendingClaims()
        {
            var pendingClaims = _dbContext.Claims.Where(c => c.Status == "Pending").ToList(); // Get all claims with "Pending" status
            return View(pendingClaims); // Display the pending claims in the view
        }

        // POST action to approve a claim (update status to Verified)
        [HttpPost]
        public IActionResult ApproveClaim(int claimId)
        {
            var claim = _dbContext.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Verified"; // Update the status to Verified
                _dbContext.SaveChanges();
            }

            // Redirect back to the pending claims page after approval
            return RedirectToAction("PendingClaims");
        }

        // POST action to reject a claim (update status to Rejected with rejection reason)
        [HttpPost]
        public IActionResult RejectClaim(int claimId, string rejectionReason)
        {
            var claim = _dbContext.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Rejected"; // Update the status to Rejected
                claim.RejectionReason = rejectionReason; // Save the rejection reason
                _dbContext.SaveChanges();
            }

            // Redirect back to the pending claims page after rejection
            return RedirectToAction("PendingClaims");
        }
    }
}
