namespace ContractsAppProg.Models
{
    public class Claim
    {
        public int ClaimId { get; set; } // Primary Key (if ClaimId is the main unique identifier)

        public string LecturerName { get; set; } // Name of the lecturer
        public string LecturerEmail { get; set; } // Email of the lecturer
        public int LecturerID { get; set; } // Lecturer ID (could be used for unique identification)

        public double HoursWorked { get; set; } // Number of hours worked
        public double HourlyRate { get; set; } // Hourly rate of the lecturer

        public string AdditionalNotes { get; set; } // Any additional notes provided by the lecturer
        public string RejectionReason { get; set; } // Reason for rejection if applicable
        public string SupportingDocumentPath { get; set; } // Path to the supporting document (if any)

        public string Status { get; set; } // Status of the claim: Pending, Verified, Rejected, etc.

        // Optional: You might want to add validation or additional logic (e.g., for proper email format or rate)
    }
}
