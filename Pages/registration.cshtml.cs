using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace greenlane.Pages;

public class RegistrationModel : PageModel
{
    [BindProperty]
    public RegistrationInput Input { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            // Use your Gmail address
            string myEmail = "macshap04@gmail.com";
            // Your 16-character Google App Password
            string appPassword = "pemdnxbqiovbvtuk";

            // Create SMTP client
            using SmtpClient smtp = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myEmail, appPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 30000 // 30 seconds timeout
            };

            // Create email message
            MailMessage mail = new()
            {
                From = new MailAddress(myEmail, "Greenlane College Admissions"),
                Subject = $"NEW 2026 Registration: {Input.ChildName}",
                Body = $@"
===========================================
       GREENLANE COLLEGE - 2026 REGISTRATION
===========================================

STUDENT INFORMATION:
-------------------
Full Name: {Input.ChildName}
Grade Applied: {Input.AppliedGrade}
Date of Birth: {Input.ChildDOB?.ToString("dd MMMM yyyy") ?? "Not provided"}
Previous School: {Input.PreviousSchool ?? "Not provided"}

PARENT/GUARDIAN INFORMATION:
---------------------------
Primary Contact: {Input.ParentName}
Relationship: {Input.Relationship}
Email Address: {Input.ParentEmail}
Phone Number: {Input.ParentPhone}
Home Address: {Input.Address}
Emergency Contact: {Input.EmergencyContact} ({Input.EmergencyPhone})

ADDITIONAL INFORMATION:
----------------------
Home Language: {Input.HomeLanguage}
Additional Language: {Input.AdditionalLanguage ?? "Not specified"}

APPLICATION DETAILS:
-------------------
Application Date: {DateTime.Now:dd MMMM yyyy HH:mm}
Application Year: 2026
Reference Number: GL-{Guid.NewGuid().ToString()[..8].ToUpper()}

===========================================
This is an automated notification. Please do not reply.
Contact admissions at info@greenlane.co.za for queries.
===========================================",
                IsBodyHtml = false,
                Priority = MailPriority.High
            };

            // Set recipients
            mail.To.Add(myEmail); // Send to yourself
            mail.ReplyToList.Add(new MailAddress(Input.ParentEmail, Input.ParentName));

            // Send email
            await smtp.SendMailAsync(mail);

            // Also send a confirmation email to parent
            await SendConfirmationEmailToParent(myEmail, appPassword);

            // Store success data
            TempData["ApplicationReference"] = $"GL-{Guid.NewGuid().ToString()[..8].ToUpper()}";
            TempData["ChildName"] = Input.ChildName;
            TempData["ParentEmail"] = Input.ParentEmail;
            TempData["AppliedGrade"] = Input.AppliedGrade;
            TempData["SubmissionDate"] = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            TempData["SuccessMessage"] = "Your 2026 application has been submitted successfully!";

            return RedirectToPage("RegistrationSuccess");
        }
        catch (SmtpException smtpEx)
        {
            ModelState.AddModelError("", $"SMTP Error: {smtpEx.Message}. Please check your email settings.");
            return Page();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error: {ex.Message}. Please try again or contact support.");
            return Page();
        }
    }

    private async Task SendConfirmationEmailToParent(string myEmail, string appPassword)
    {
        try
        {
            using SmtpClient smtp = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myEmail, appPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 30000
            };

            MailMessage confirmation = new()
            {
                From = new MailAddress(myEmail, "Greenlane College Admissions"),
                Subject = "Your 2026 Application Has Been Received",
                Body = $@"
Dear {Input.ParentName},

Thank you for submitting your application to Greenlane College for the 2026 academic year!

APPLICATION SUMMARY:
-------------------
Student: {Input.ChildName}
Grade Applied: {Input.AppliedGrade}
Application Date: {DateTime.Now:dd MMMM yyyy}
Application Reference: GL-{Guid.NewGuid().ToString()[..8].ToUpper()}

NEXT STEPS:
----------
1. Our admissions team will review your application within 5-7 working days
2. You will receive a follow-up email with payment details for the R250 application fee
3. Please ensure you have the following documents ready for submission:
   - Birth Certificate
   - Immunization Records
   - Proof of Residence
   - Parent/Guardian ID Copy
   - Most recent school report (if applicable)

IMPORTANT INFORMATION:
---------------------
- Application Fee: R250 (non-refundable)
- Application does not guarantee admission
- All documents must be submitted within 14 days
- Placement is subject to availability

CONTACT US:
----------
Email: info@greenlane.co.za
Phone: +27 11 492 1778 / +27 81 262 4572
Hours: Mon-Fri 8:00 AM - 4:00 PM

We look forward to welcoming {Input.ChildName} to our Greenlane College community!

Best regards,
Greenlane College Admissions Team
---------------------------------
Greenlane College
Excellence in Education Since 2009",
                IsBodyHtml = false
            };

            confirmation.To.Add(Input.ParentEmail);
            await smtp.SendMailAsync(confirmation);
        }
        catch (Exception)
        {
            // Silent fail - we already sent email to admin
        }
    }
}

public class RegistrationInput
{
    [Required(ErrorMessage = "Student name is required")]
    [Display(Name = "Child's Full Name")]
    public string ChildName { get; set; } = "";

    [Required(ErrorMessage = "Please select a grade")]
    [Display(Name = "Grade Applying For")]
    public string AppliedGrade { get; set; } = "";

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime? ChildDOB { get; set; }

    [Display(Name = "Previous School")]
    public string? PreviousSchool { get; set; }

    [Required(ErrorMessage = "Parent name is required")]
    [Display(Name = "Parent/Guardian Name")]
    public string ParentName { get; set; } = "";

    [Required(ErrorMessage = "Relationship is required")]
    [Display(Name = "Relationship to Child")]
    public string Relationship { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "Email Address")]
    public string ParentEmail { get; set; } = "";

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [Display(Name = "Phone Number")]
    public string ParentPhone { get; set; } = "";

    [Required(ErrorMessage = "Address is required")]
    [Display(Name = "Home Address")]
    public string Address { get; set; } = "";

    [Required(ErrorMessage = "Emergency contact is required")]
    [Display(Name = "Emergency Contact Name")]
    public string EmergencyContact { get; set; } = "";

    [Required(ErrorMessage = "Emergency phone is required")]
    [Phone(ErrorMessage = "Please enter a valid emergency phone number")]
    [Display(Name = "Emergency Phone")]
    public string EmergencyPhone { get; set; } = "";

    [Required(ErrorMessage = "Home language is required")]
    [Display(Name = "Home Language")]
    public string HomeLanguage { get; set; } = "";

    [Display(Name = "Additional Language")]
    public string? AdditionalLanguage { get; set; }
}