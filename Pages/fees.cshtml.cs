using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace greenlane.Pages
{
    public class FeesModel : PageModel
    {
        public string PageTitle { get; set; } = "2026 Fee Structure";

        public List<FeeCategory> PrimarySchoolFees { get; set; }
        public List<FeeCategory> HighSchoolFees { get; set; }

        public void OnGet()
        {
            // Initializing data during the GET request
            PrimarySchoolFees = new List<FeeCategory>
            {
                new FeeCategory { Grades = "1-3", RegistrationFee = 600, MonthlyFee = 850 },
                new FeeCategory { Grades = "4-5", RegistrationFee = 600, MonthlyFee = 900 },
                new FeeCategory { Grades = "6-7", RegistrationFee = 600, MonthlyFee = 950 }
            };

            HighSchoolFees = new List<FeeCategory>
            {
                new FeeCategory { Grades = "8", RegistrationFee = 700, MonthlyFee = 1000 },
                new FeeCategory { Grades = "9", RegistrationFee = 900, MonthlyFee = 1050 },
                new FeeCategory { Grades = "10", RegistrationFee = 1000, MonthlyFee = 1200 },
                new FeeCategory { Grades = "11", RegistrationFee = 1000, MonthlyFee = 1400 },
                new FeeCategory { Grades = "12", RegistrationFee = 1500, MonthlyFee = 2100 }
            };
        }
    }

    public class FeeCategory
    {
        public string Grades { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal AnnualTotal => MonthlyFee * 10; // Assuming 10-month payment cycle
    }
}
