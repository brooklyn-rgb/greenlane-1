using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class RegistrationSuccessModel : PageModel
    {
        public string? ApplicationReference { get; set; }
        public string? ChildName { get; set; }
        public string? ParentEmail { get; set; }
        public string? AppliedGrade { get; set; }
        public string? SubmissionDate { get; set; }

        public void OnGet()
        {
            // Retrieve data from TempData
            ApplicationReference = TempData["ApplicationReference"] as string;
            ChildName = TempData["ChildName"] as string;
            ParentEmail = TempData["ParentEmail"] as string;
            AppliedGrade = TempData["AppliedGrade"] as string;
            SubmissionDate = TempData["SubmissionDate"] as string;
        }
    }
}