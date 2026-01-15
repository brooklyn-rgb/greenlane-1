using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greenlane.Pages
{
    public class GalleryModel : PageModel
    {
        public List<GalleryImage> Images { get; set; } = new();
        public List<GalleryVideo> Videos { get; set; } = new();

        public void OnGet()
        {
            // Initialize gallery images
            Images = new List<GalleryImage>
            {
                new GalleryImage
                {
                    Id = 1,
                    Category = "academic",
                    Title = "Science Lab Discovery",
                    Description = "Grade 6 students conducting experiments",
                    ImageUrl = "/images/banner/academics.png",
                    Date = "2025-01-15"
                },
                new GalleryImage
                {
                    Id = 2,
                    Category = "sports",
                    Title = "Sports Day Champions",
                    Description = "Annual inter-house sports competition",
                    ImageUrl = "/images/gallery/sport2.webp",
                    Date = "2025-02-20"
                },
                new GalleryImage
                {
                    Id = 3,
                    Category = "arts",
                    Title = "Art Exhibition",
                    Description = "Student artwork display",
                    ImageUrl = "/images/gallery/tour.webp",
                    Date = "2025-03-10"
                },
                new GalleryImage
                {
                    Id = 4,
                    Category = "events",
                    Title = "Cultural Day",
                    Description = "Celebrating South African heritage",
                    ImageUrl = "/images/gallery/tour2.webp",
                    Date = "2025-04-05"
                },
                new GalleryImage
                {
                    Id = 5,
                    Category = "academic",
                    Title = "Reading Corner",
                    Description = "Early learning literacy program",
                    ImageUrl = "/images/gallery/senior.webp",
                    Date = "2025-01-30"
                },
                new GalleryImage
                {
                    Id = 6,
                    Category = "sports",
                    Title = "Swimming Lessons",
                    Description = "Junior swimming program",
                    ImageUrl = "/images/gallery/lessons.webp",
                    Date = "2025-02-15"
                },
                new GalleryImage
                {
                    Id = 7,
                    Category = "arts",
                    Title = "Music Class",
                    Description = "Learning traditional instruments",
                    ImageUrl = "https://images.unsplash.com/photo-1511379938547-c1f69419868d?w=800&q=80",
                    Date = "2025-03-25"
                },
                new GalleryImage
                {
                    Id = 8,
                    Category = "events",
                    Title = "Graduation Ceremony",
                    Description = "Grade 7 graduation celebration",
                    ImageUrl = "https://images.unsplash.com/photo-1541692641319-981cc79ee10a?w=800&q=80",
                    Date = "2025-04-30"
                },
                new GalleryImage
                {
                    Id = 9,
                    Category = "facilities",
                    Title = "Modern Library",
                    Description = "Our state-of-the-art resource center",
                    ImageUrl = "/images/gallery/boys.webp",
                    Date = "2025-01-10"
                },
                new GalleryImage
                {
                    Id = 10,
                    Category = "academic",
                    Title = "Math Class",
                    Description = "Interactive mathematics learning",
                    ImageUrl = "https://images.unsplash.com/photo-1635070041078-e363dbe005cb?w=800&q=80",
                    Date = "2025-02-25"
                },
                new GalleryImage
                {
                    Id = 11,
                    Category = "sports",
                    Title = "Marathon Chanpions",
                    Description = "High school Marathon Chanpions",
                    ImageUrl = "/images/banner/sports.jpg",
                    Date = "2025-03-15"
                },
                new GalleryImage
                {
                    Id = 12,
                    Category = "events",
                    Title = "Science Fair",
                    Description = "Annual science exhibition",
                    ImageUrl = "/images/gallery/child.webp",
                    Date = "2025-04-20"
                }
            };

            // Initialize videos
            Videos = new List<GalleryVideo>
            {
                new GalleryVideo
                {
                    Id = 1,
                    Title = "Virtual Campus Tour",
                    Description = "Take a guided tour of our facilities and classrooms",
                    VideoUrl = "https://www.youtube.com/embed/dQw4w9WgXcQ",
                    Thumbnail = "https://img.youtube.com/vi/dQw4w9WgXcQ/hqdefault.jpg",
                    Duration = "5:30"
                },
                new GalleryVideo
                {
                    Id = 2,
                    Title = "Annual Music Concert",
                    Description = "Highlights from our 2024 annual musical performance",
                    VideoUrl = "https://www.youtube.com/embed/dQw4w9WgXcQ",
                    Thumbnail = "https://img.youtube.com/vi/dQw4w9WgXcQ/hqdefault.jpg",
                    Duration = "8:15"
                },
                new GalleryVideo
                {
                    Id = 3,
                    Title = "Sports Day Highlights",
                    Description = "Best moments from our annual sports day",
                    VideoUrl = "https://www.youtube.com/embed/dQw4w9WgXcQ",
                    Thumbnail = "https://img.youtube.com/vi/dQw4w9WgXcQ/hqdefault.jpg",
                    Duration = "6:45"
                }
            };
        }
    }

    public class GalleryImage
    {
        public int Id { get; set; }
        public string Category { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Date { get; set; } = "";
    }

    public class GalleryVideo
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string VideoUrl { get; set; } = "";
        public string Thumbnail { get; set; } = "";
        public string Duration { get; set; } = "";
    }
}