// Pages/admissions.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class AdmissionsModel : PageModel
    {
        public bool IsEarlyRegistrationOpen { get; set; } = true;
        public DateTime EarlyRegistrationDeadline { get; set; } = new DateTime(2026, 3, 31);

        // Example data for requirements
        public class GradeRequirement
        {
            public string Grade { get; set; }
            public List<string> Requirements { get; set; }
        }

        public List<GradeRequirement> Requirements { get; set; }

        public AdmissionsModel()
        {
            // Initialize requirements data
            Requirements = new List<GradeRequirement>
            {
                new GradeRequirement
                {
                    Grade = "Grade 1",
                    Requirements = new List<string>
                    {
                        "Child must turn 6 years old in 2026",
                        "Birth Certificate",
                        "Immunization Record",
                        "Preschool Report (if applicable)"
                    }
                },
                new GradeRequirement
                {
                    Grade = "Grade 8-12",
                    Requirements = new List<string>
                    {
                        "Satisfactory academic record",
                        "Previous school reports (last 2 years)",
                        "Transfer certificate",
                        "Successful assessment test"
                    }
                }
            };
        }

        public void OnGet()
        {
            // Initialize page data
        }
    }
}