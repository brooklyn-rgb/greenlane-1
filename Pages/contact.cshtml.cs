using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

namespace greenlane.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Your name is required")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = "";

        [BindProperty]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a subject")]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Please enter your message")]
        [Display(Name = "Message")]
        [StringLength(2000, ErrorMessage = "Message cannot exceed 2000 characters")]
        public string Message { get; set; } = "";

        [BindProperty]
        [Display(Name = "I would like to receive updates and newsletters")]
        public bool SubscribeToNewsletter { get; set; }

        public List<string> Subjects { get; set; } = new();
        public List<DepartmentContact> Departments { get; set; } = new();
        public List<SchoolHour> SchoolHours { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            InitializeData();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                InitializeData();
                return Page();
            }

            try
            {
                // Here you would typically:
                // 1. Save to database
                // 2. Send email notification
                // 3. Send auto-response to user

                // Example email sending (commented out for safety)
                /*
                using (var client = new SmtpClient("smtp.yourserver.com", 587))
                {
                    client.Credentials = new NetworkCredential("your-email@greenlane.co.za", "your-password");
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("noreply@greenlane.co.za"),
                        Subject = $"New Contact Form: {Subject}",
                        Body = $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nMessage: {Message}",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add("info@greenlane.co.za");

                    await client.SendMailAsync(mailMessage);
                }
                */

                SuccessMessage = "Thank you for your message! We have received your inquiry and will respond within 24-48 hours during business days.";
                return RedirectToPage("/Contact");
            }
            catch (Exception)
            {
                ErrorMessage = "There was an error sending your message. Please try again or call us directly.";
                InitializeData();
                return Page();
            }
        }

        private void InitializeData()
        {
            Subjects = new List<string>
            {
                "General Inquiry",
                "Admissions Information",
                "School Tour Booking",
                "Academic Programs",
                "Fee Structure",
                "Transportation Services",
                "Extracurricular Activities",
                "Employment Opportunities",
                "Technical Support",
                "Other"
            };

            Departments = new List<DepartmentContact>
            {
                new DepartmentContact
                {
                    Department = "Admissions Office",
                    Person = "Mrs. Thandi Ndlovu",
                    Email = "admissions@greenlane.co.za",
                    Phone = "+27 11 492 1778",
                    Ext = "101",
                    Hours = "Mon-Fri: 8:00 AM - 4:00 PM"
                },
                new DepartmentContact
                {
                    Department = "Principal's Office",
                    Person = "Mr. Jamil Lubega",
                    Email = "principal@greenlane.co.za",
                    Phone = "+27 11 492 1778",
                    Ext = "102",
                    Hours = "By appointment only"
                },
                new DepartmentContact
                {
                    Department = "Finance & Billing",
                    Person = "Ms. Sarah van der Merwe",
                    Email = "finance@greenlane.co.za",
                    Phone = "+27 11 492 1779",
                    Ext = "103",
                    Hours = "Mon-Fri: 8:30 AM - 3:30 PM"
                },
                new DepartmentContact
                {
                    Department = "Student Support",
                    Person = "Dr. David Moloi",
                    Email = "support@greenlane.co.za",
                    Phone = "+27 11 492 1780",
                    Ext = "104",
                    Hours = "Mon-Fri: 8:00 AM - 3:00 PM"
                }
            };

            SchoolHours = new List<SchoolHour>
            {
                new SchoolHour { Day = "Monday - Thursday", Hours = "7:30 AM - 2:30 PM", Notes = "Academic Instruction" },
                new SchoolHour { Day = "Friday", Hours = "7:30 AM - 1:00 PM", Notes = "Academic & Assembly" },
                new SchoolHour { Day = "Office Hours", Hours = "8:00 AM - 4:30 PM", Notes = "Administration" },
                new SchoolHour { Day = "Saturday", Hours = "8:00 AM - 12:00 PM", Notes = "Extra Classes & Sports" },
                new SchoolHour { Day = "Sunday", Hours = "Closed", Notes = "Family Day" }
            };
        }
    }

    public class DepartmentContact
    {
        public string Department { get; set; } = "";
        public string Person { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Ext { get; set; } = "";
        public string Hours { get; set; } = "";
    }

    public class SchoolHour
    {
        public string Day { get; set; } = "";
        public string Hours { get; set; } = "";
        public string Notes { get; set; } = "";
    }
}