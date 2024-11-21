
namespace ContactsAppProg.Models
{
    public class SubmitClaimViewModel
    {
        public string LecturerName { get; set; }
        public string LecturerEmail { get; set; }
        public string LecturerID { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string AdditionalNotes { get; set; }
        public IFormFile SupportingDocument { get; set; }
    }
}
