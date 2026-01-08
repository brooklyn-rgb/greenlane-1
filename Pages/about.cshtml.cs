// Pages/About.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class AboutModel : PageModel
    {
        public List<CoreValue> CoreValues { get; set; } = new();
        public List<MissionPoint> MissionPoints { get; set; } = new();

        public void OnGet()
        {
            // Initialize Core Values
            CoreValues = new List<CoreValue>
            {
                new CoreValue { 
                    Title = "Passion for Potential", 
                    Description = "We are deeply committed to delivering relevant knowledge, skills, and values with unwavering enthusiasm, empowering each learner to realize their full potential and make a positive impact in their community."
                },
                new CoreValue { 
                    Title = "Mutual Respect", 
                    Description = "We cultivate an environment of high regard for the dignity of every individual, expecting and encouraging respectful conduct from all stakeholders within our established legal and ethical frameworks."
                },
                new CoreValue { 
                    Title = "Collaborative Excellence", 
                    Description = "We recognize the interdependence of our work and believe that harmonious, purpose-driven teamwork is fundamental to achieving effective and outstanding educational outcomes."
                },
                new CoreValue { 
                    Title = "Dedicated Service", 
                    Description = "We ensure the efficient and effective application of our resources and expertise to provide facilities and education that yield the utmost benefit and growth for every learner."
                },
                new CoreValue { 
                    Title = "Integrity & Discipline", 
                    Description = "We are committed to upholding the highest standards of positive discipline and ethical behavior, ensuring a safe, structured, and conducive environment for learning and personal development."
                }
            };

            // Initialize Mission Points
            MissionPoints = new List<MissionPoint>
            {
                new MissionPoint { 
                    Title = "Our Mission", 
                    Description = "To champion exceptional teaching and learning while fostering intrinsic self-worth among both our educators and students, creating a foundation for lifelong achievement.",
                    IconClass = "bi-bullseye"
                },
                new MissionPoint { 
                    Title = "Our Vision", 
                    Description = "To be recognized as the preeminent provider of transformative, high-caliber education and training across all academic levels in South Africa.",
                    IconClass = "bi-eye"
                },
                new MissionPoint { 
                    Title = "Our Strategic Objective", 
                    Description = "To impart a robust body of knowledge, critical skills, and enduring values that are recognized and sought after by leading tertiary institutions and employers.",
                    IconClass = "bi-flag"
                }
            };
        }
    }

    public class CoreValue
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }

    public class MissionPoint
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string IconClass { get; set; } = "";
    }
}