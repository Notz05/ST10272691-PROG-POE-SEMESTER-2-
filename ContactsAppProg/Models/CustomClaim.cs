public class CustomClaim
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string Status { get; set; }  // Pending, Approved, Rejected
}
