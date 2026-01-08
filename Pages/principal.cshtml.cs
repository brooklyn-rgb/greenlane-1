// Pages/principal.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class PrincipalModel : PageModel
    {
        // Add properties if you need dynamic data
        public string PrincipalName { get; set; } = "Jamil Lubega";
        public string PrincipalTitle { get; set; } = "Principal & Academic Director";

        public void OnGet()
        {
            // Initialize any data needed for the page
        }
    }
}