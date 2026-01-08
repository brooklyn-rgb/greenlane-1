// Models/SchoolInfo.cs
using System.Collections.Generic;

namespace greenlane.Models
{
    public class SchoolInfo
    {
        public string Mission { get; set; } = "To promote high quality teaching and learning and self-worth among our staff and learners";
        public string Vision { get; set; } = "To be the leading provider of high quality education and training at all levels";
        public string StrategicObjective { get; set; } = "To position the Greenlane College as a transformative and sustainable learning centre";
        public List<FAQ> FrequentlyAskedQuestions { get; set; } = new();
        public string ContactEmail { get; set; } = "info@greenlane.co.za";
        public string PhoneNumber { get; set; } = "+27 11 123 4567";
    }

    public class FAQ
    {
        public string Question { get; set; } = "";
        public string Answer { get; set; } = "";
    }
}