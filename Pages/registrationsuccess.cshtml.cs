using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages;

public class RegistrationSuccessModel : PageModel
{
    public string? ApplicationReference { get; set; }
    public string? ChildName { get; set; }
    public string? ParentEmail { get; set; }
    public string? AppliedGrade { get; set; }
    public string? SubmissionDate { get; set; }

    public void OnGet()
    {
        // Use .Peek() so data isn't deleted if the user refreshes the page
        ApplicationReference = TempData.Peek("ApplicationReference")?.ToString();
        ChildName = TempData.Peek("ChildName")?.ToString();
        ParentEmail = TempData.Peek("ParentEmail")?.ToString();
        AppliedGrade = TempData.Peek("AppliedGrade")?.ToString();
        SubmissionDate = TempData.Peek("SubmissionDate")?.ToString();
    }
}
