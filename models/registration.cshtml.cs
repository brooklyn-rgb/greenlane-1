// Pages/Registration.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace greenlane.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Child's name is required")]
        [Display(Name = "Child's Full Name")]
        public string ChildName { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Date of birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? ChildDOB { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a grade")]
        [Display(Name = "Applying for Grade")]
        public string Grade { get; set; } = "";

        [BindProperty]
        [Display(Name = "Previous School")]
        public string? PreviousSchool { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Parent/Guardian name is required")]
        [Display(Name = "Parent/Guardian Name")]
        public string ParentName { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Relationship is required")]
        [Display(Name = "Relationship to Child")]
        public string Relationship { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string ParentEmail { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string ParentPhone { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Home Address")]
        public string Address { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Emergency contact is required")]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Emergency phone is required")]
        [Display(Name = "Emergency Phone")]
        public string EmergencyPhone { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "You must agree to the terms")]
        public bool TermsAgreed { get; set; }

        public List<string> Grades { get; set; } = new();

        public void OnGet()
        {
            // Initialize with current date for DOB picker
            if (!ChildDOB.HasValue)
            {
                ChildDOB = DateTime.Now.AddYears(-10); // Default 10 years old
            }

            // Populate grades R-12
            Grades = new List<string>
            {
                "Grade 1",
                "Grade 1", "Grade 2", "Grade 3", "Grade 4", "Grade 5", "Grade 6",
                "Grade 7", "Grade 8", "Grade 9", "Grade 10", "Grade 11", "Grade 12"
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet(); // Repopulate dropdowns
                return Page();
            }

            // Generate 2026 application reference
            var applicationRef = $"GL2026-{DateTime.Now:MMdd}-{new Random().Next(1000, 9999)}";

            // Store in TempData for success page
            TempData["ApplicationReference"] = applicationRef;
            TempData["ChildName"] = ChildName;
            TempData["ParentEmail"] = ParentEmail;
            TempData["AppliedGrade"] = Grade;
            TempData["SubmissionDate"] = DateTime.Now.ToString("dd MMMM yyyy");
            TempData["AcademicYear"] = "2026";

            // Here you would typically save to database and send email

            return RedirectToPage("/RegistrationSuccess");
        }
    }
}