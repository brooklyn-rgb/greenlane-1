// Models/SchoolInfo.cs
using System.Collections.Generic;

namespace greenlane.Models
{
    public class SchoolInfo
    {
        public string Mission { get; set; } = "We are commited to fostering excellence in teaching, igniting a passion for learning, and nurturing the intrinsic value of every individual in our community.";
        public string Vision { get; set; } = "We envision a future where Greenlane College is the undisputed benchmark for educational excellence and innovation at every stage.";
        public string StrategicObjective { get; set; } = "Our focused aim is to cement Greenlane College's legacy as a resilient and revolutionary center for lifelong growth.";
        public List<FAQ> FrequentlyAskedQuestions { get; set; } = new();
        public string ContactEmail { get; set; } = "info@greenlane.co.za";
        public string PhoneNumber { get; set; } = "+27 11 492 1778";
    }

    public class FAQ
    {
        public string Question { get; set; } = "";
        public string Answer { get; set; } = "";
    }
}