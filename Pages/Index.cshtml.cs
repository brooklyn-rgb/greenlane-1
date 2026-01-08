// Pages/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using greenlane.Models;

namespace greenlane.Pages
{
    public class IndexModel : PageModel
    {
        public SchoolInfo SchoolInfo { get; set; }

        public IndexModel()
        {
            SchoolInfo = new SchoolInfo
            {
                FrequentlyAskedQuestions = new List<FAQ>
                {
                    new FAQ
                    {
                        Question = "When does registration start?",
                        Answer = "Registration for the 2025 academic year is currently in progress."
                    },
                    new FAQ
                    {
                        Question = "Are there any free packages available?",
                        Answer = "Yes, we have limited free packages available for early registrations."
                    }
                }
            };
        }

        public void OnGet()
        {
            // Additional data loading if needed
        }
    }
}