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
                    Title = "Passion", 
                    Description = "We are deeply committed to providing relevant knowledge, skills and values to learners, doing this with enthusiasm and dedication to enable learners realize their potential and have a positive impact in their lives and community."
                },
                new CoreValue { 
                    Title = "Respect", 
                    Description = "We emphasize high regard for the dignity of all people, encouraging respectful conduct by all stakeholders at all times and in accordance with legal frameworks, policies and procedures."
                },
                new CoreValue { 
                    Title = "TeamWork", 
                    Description = "We appreciate that all aspects of our work are interdependent and believe that operating in harmonious teams leads to more effective and efficient results."
                },
                new CoreValue { 
                    Title = "Serving Clients", 
                    Description = "We ensure efficient and effective application of our capabilities to provide facilities, skills, and knowledge in a manner that yields utmost benefits to learners."
                },
                new CoreValue { 
                    Title = "Discipline", 
                    Description = "We are committed to enforcing high standards of positive discipline through engagement and strict enforcement of guidelines, policies, and procedures to ensure safety, comfort, and good behavior."
                }
            };

            // Initialize Mission Points
            MissionPoints = new List<MissionPoint>
            {
                new MissionPoint { 
                    Title = "Our Mission", 
                    Description = "To promote high quality teaching and learning and self-worth among our staff and learners.",
                    IconClass = "bi-bullseye"
                },
                new MissionPoint { 
                    Title = "Our Vision", 
                    Description = "To be the leading provider of high quality education and training at all levels.",
                    IconClass = "bi-eye"
                },
                new MissionPoint { 
                    Title = "Our Strategic Objective", 
                    Description = "To position the Greenlane College as a transformative and sustainable learning centre.",
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