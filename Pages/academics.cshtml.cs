using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class AcademicsModel : PageModel
    {
        public List<AcademicPhase> AcademicPhases { get; set; } = new();
        public List<Subject> FoundationPhaseSubjects { get; set; } = new();
        public List<Subject> IntermediatePhaseSubjects { get; set; } = new();
        public List<Subject> SeniorPhaseSubjects { get; set; } = new();
        public List<Subject> FETPhaseSubjects { get; set; } = new();

        public void OnGet()
        {
            InitializeAcademicStructure();
            InitializeSubjects();
        }

        private void InitializeAcademicStructure()
        {
            AcademicPhases = new List<AcademicPhase>
            {
                new AcademicPhase
                {
                    Phase = "Foundation Phase",
                    Grades = "Grade 1 - 3",
                    AgeRange = "Ages 5-9",
                    Description = "Lays the groundwork for literacy, numeracy, and life skills, ensuring cognitive and emotional development in early learners aged 5-9.",
                    ImageUrl = "https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Icon = "bi-house-door",
                    Color = "foundation"
                },
                new AcademicPhase
                {
                    Phase = "Intermediate Phase",
                    Grades = "Grade 4 - 6",
                    AgeRange = "Ages 9-12",
                    Description = "Builds on foundational knowledge by introducing more complex problem-solving, languages, sciences, and social studies.",
                    ImageUrl = "/images/gallery/computer-lessons.jpeg",
                    Icon = "bi-book",
                    Color = "intermediate"
                },
                new AcademicPhase
                {
                    Phase = "Senior Phase",
                    Grades = "Grade 7 - 9",
                    AgeRange = "Ages 12-15",
                    Description = "Prepares learners for specialization with deeper knowledge in sciences, languages, creative arts, and technology.",
                    ImageUrl = "https://images.unsplash.com/photo-1519389950473-47ba0277781c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    Icon = "bi-mortarboard",
                    Color = "senior"
                },
                new AcademicPhase
                {
                    Phase = "FET Phase",
                    Grades = "Grade 10 - 12",
                    AgeRange = "Ages 15-18",
                    Description = "Focused specialization for career pathways and higher education readiness with advanced subjects across multiple discipline.",
                    ImageUrl = "/images/gallery/teacher.jpeg",
                    Icon = "bi-award",
                    Color = "fet"
                }
            };
        }

        private void InitializeSubjects()
        {
            // Foundation Phase Subjects
            FoundationPhaseSubjects = new List<Subject>
            {
                new Subject { Name = "Foundation Numeracy | Mathematics", Category = "Core", Hours = "7 hours/week" },
                new Subject { Name = "Literacy (English Home Language)", Category = "Core", Hours = "7 hours/week" },
                new Subject { Name = "Afrikaans FAL", Category = "Language", Hours = "4 hours/week" },
                new Subject { Name = "Life Skills", Category = "Development", Hours = "6 hours/week" }
            };

            // Intermediate Phase Subjects
            IntermediatePhaseSubjects = new List<Subject>
            {
                new Subject { Name = "Mathematics", Category = "Core", Hours = "6 hours/week" },
                new Subject { Name = "Natural Science & Technology", Category = "Science", Hours = "5 hours/week" },
                new Subject { Name = "Social Sciences", Category = "Humanities", Hours = "4 hours/week" },
                new Subject { Name = "English Home Language", Category = "Language", Hours = "6 hours/week" },
                new Subject { Name = "Afrikaans FAL", Category = "Language", Hours = "4 hours/week" },
                new Subject { Name = "Life Skills", Category = "Development", Hours = "4 hours/week" }
            };

            // Senior Phase Subjects
            SeniorPhaseSubjects = new List<Subject>
            {
                new Subject { Name = "Mathematics", Category = "Core", Hours = "5 hours/week" },
                new Subject { Name = "English Home Language", Category = "Language", Hours = "5 hours/week" },
                new Subject { Name = "Afrikaans FAL", Category = "Language", Hours = "4 hours/week" },
                new Subject { Name = "Life Orientation", Category = "Development", Hours = "2 hours/week" },
                new Subject { Name = "IsiZulu FAL", Category = "Language", Hours = "4 hours/week" },
                new Subject { Name = "Technology", Category = "Technical", Hours = "2 hours/week" },
                new Subject { Name = "Natural Sciences", Category = "Science", Hours = "4 hours/week" },
                new Subject { Name = "Social Sciences", Category = "Humanities", Hours = "4 hours/week" },
                new Subject { Name = "Creative Arts", Category = "Arts", Hours = "2 hours/week" }
            };

            // FET Phase Subjects (with subject choices)
            FETPhaseSubjects = new List<Subject>
            {
                // Core Subjects
                new Subject { Name = "English Home Language", Category = "Core", Hours = "5 hours/week", IsCore = true },
                new Subject { Name = "Afrikaans FAL", Category = "Core", Hours = "4 hours/week", IsCore = true },
                new Subject { Name = "IsiZulu FAL", Category = "Core", Hours = "4 hours/week", IsCore = true },
                new Subject { Name = "Life Orientation", Category = "Core", Hours = "2 hours/week", IsCore = true },
                
                // Mathematics Choices
                new Subject { Name = "Mathematics", Category = "Mathematics", Hours = "5 hours/week", IsCore = false },
                new Subject { Name = "Mathematical Literacy", Category = "Mathematics", Hours = "4 hours/week", IsCore = false },
                
                // Science Stream
                new Subject { Name = "Physical Sciences", Category = "Science", Hours = "5 hours/week", IsCore = false },
                new Subject { Name = "Life Sciences", Category = "Science", Hours = "4 hours/week", IsCore = false },
                
                // Commerce Stream
                new Subject { Name = "Business Studies", Category = "Commerce", Hours = "4 hours/week", IsCore = false },
                new Subject { Name = "Economics", Category = "Commerce", Hours = "4 hours/week", IsCore = false },
                new Subject { Name = "Religion Studies", Category = "Commerce", Hours = "4 hours/week", IsCore = false },
                
                // Humanities Stream
                new Subject { Name = "Geography", Category = "Humanities", Hours = "4 hours/week", IsCore = false },
                new Subject { Name = "History", Category = "Humanities", Hours = "4 hours/week", IsCore = false },
                
                // Technical Stream
                new Subject { Name = "Computer Applications Technology (CAT)", Category = "Technical", Hours = "3 hours/week", IsCore = false },
                new Subject { Name = "Tourism", Category = "Technical", Hours = "3 hours/week", IsCore = false }
            };
        }
    }

    public class AcademicPhase
    {
        public string Phase { get; set; } = "";
        public string Grades { get; set; } = "";
        public string AgeRange { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Icon { get; set; } = "";
        public string Color { get; set; } = "";
    }

    public class Subject
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Hours { get; set; } = "";
        public bool IsCore { get; set; } = false;
    }
}