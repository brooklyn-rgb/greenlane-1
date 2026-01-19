using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace greenlane.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public RegistrationInput Input { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        try
        {
            string myEmail = "macshap04@gmail.com";
            // Use your 16-character Google App Password here
            string appPassword = "pemdnxbqiovbvtuk";

            // FIX: Simplified 'new' expression (Target-typed new)
            using SmtpClient smtp = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myEmail, appPassword),
                EnableSsl = true
            };

            // FIX: Simplified object initialization
            MailMessage mail = new()
            {
                From = new(myEmail, "Greenlane Admissions"),
                Subject = $"New Registration 2026: {Input.ChildName}",
                Body = $@"
                    NEW STUDENT APPLICATION - 2026
                    -------------------------------
                    Student Name: {Input.ChildName}
                    Grade Applied: {Input.AppliedGrade}
                    Parent Email: {Input.ParentEmail}
                    Parent Phone: {Input.ParentPhone}
                    
                    Submitted: {DateTime.Now:dd MMMM yyyy HH:mm}",
                IsBodyHtml = false
            };
            mail.To.Add(myEmail);
            mail.ReplyToList.Add(new MailAddress(Input.ParentEmail));

            await smtp.SendMailAsync(mail);

            // FIX: Substring simplified with Range operator [..8]
            TempData["ApplicationReference"] = $"GL-{Guid.NewGuid().ToString()[..8].ToUpper()}";
            TempData["ChildName"] = Input.ChildName;
            TempData["ParentEmail"] = Input.ParentEmail;
            TempData["AppliedGrade"] = Input.AppliedGrade;
            TempData["SubmissionDate"] = DateTime.Now.ToString("dd MMMM yyyy");

            return RedirectToPage("RegistrationSuccess");
        }
        catch (Exception)
        {
            // FIX: Removed unused 'ex' variable to clear warnings
            ModelState.AddModelError("", "Registration submitted, but confirmation email failed. Check App Password.");
            return Page();
        }
    }
}

public class RegistrationInput
{
    [Required(ErrorMessage = "Student name is required")]
    public string ChildName { get; set; } = "";

    [Required(ErrorMessage = "Please select a grade")]
    public string AppliedGrade { get; set; } = "";

    [Required, EmailAddress]
    public string ParentEmail { get; set; } = "";

    [Required]
    public string ParentPhone { get; set; } = "";
}
