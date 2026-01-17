using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace greenlane.Pages
{
    public class GalleryModel : PageModel
    {
        public List<GalleryImageInfo> AllGalleryImages { get; set; } = new();
        public List<GalleryImageInfo> CarouselImages { get; set; } = new();

        public void OnGet()
        {
            var galleryDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "gallery2");

            if (Directory.Exists(galleryDir))
            {
                for (int i = 1; i <= 45; i++)
                {
                    var fileName = $"({i}).jpeg";
                    var fullPath = Path.Combine(galleryDir, fileName);

                    if (System.IO.File.Exists(fullPath))
                    {
                        var image = new GalleryImageInfo
                        {
                            Path = $"/images/gallery2/{fileName}",
                            Name = GetTitleFromNumber(i),
                            Category = GetCategoryFromNumber(i),
                            Number = i
                        };

                        AllGalleryImages.Add(image);

                        if (i <= 8) CarouselImages.Add(image);
                    }
                }
            }

            if (!AllGalleryImages.Any())
            {
                AllGalleryImages = GetFallbackImages();
                CarouselImages = AllGalleryImages.Take(6).ToList();
            }
        }

        private string GetCategoryFromNumber(int number) => number switch
        {
            <= 9 => "academic",
            <= 18 => "sports",
            <= 27 => "arts",
            <= 36 => "events",
            _ => "facilities"
        };

        private string GetTitleFromNumber(int number) => $"Photo #{number}";

        private List<GalleryImageInfo> GetFallbackImages() => new()
        {
            new GalleryImageInfo { Path="/images/banner/academics.png", Name="Academic Excellence", Category="academic", Number=1 },
            new GalleryImageInfo { Path="/images/gallery/sport2.webp", Name="Sports Champions", Category="sports", Number=2 },
            new GalleryImageInfo { Path="/images/gallery/tour.webp", Name="School Tour", Category="events", Number=3 },


    new() { Path = "/images/gallery/tour2.webp", Name = "Cultural Day", Category = "events", Number = 4 },
    new() { Path = "/images/gallery/senior.webp", Name = "Reading Corner", Category = "academic", Number = 5 },
    new() { Path = "/images/gallery/lessons.webp", Name = "Swimming Lessons", Category = "sports", Number = 6 },
    new() { Path = "/images/gallery/boys.webp", Name = "Modern Library", Category = "facilities", Number = 7 },

    new() { Path = "https://images.unsplash.com/photo-1541692641319-981cc79ee10a?w=800&q=80", Name = "Graduation Ceremony", Category = "events", Number = 8 },
    new() { Path = "https://images.unsplash.com/photo-1511379938547-c1f69419868d?w=800&q=80", Name = "Music Class", Category = "arts", Number = 9 },
    new() { Path = "/images/gallery/computer-lessons.jpeg", Name = "Computer Lessons", Category = "academic", Number = 10 },
    new() { Path = "/images/banner/sports.jpg", Name = "Marathon Champions", Category = "sports", Number = 11 },
    new() { Path = "/images/gallery/child.webp", Name = "Science Fair", Category = "events", Number = 12 },

    new() { Path = "/images/gallery2/2.jpeg", Name = "College Entrance Display", Category = "general", Number = 2 },
    new() { Path = "/images/gallery2/3.jpeg", Name = "Campus Information Display", Category = "general", Number = 3 },
    new() { Path = "/images/gallery2/4.jpeg", Name = "Student Academic Highlights", Category = "academic", Number = 4 },
    new() { Path = "/images/gallery2/5.jpeg", Name = "School Branding Banner", Category = "general", Number = 5 },
    new() { Path = "/images/gallery2/6.jpeg", Name = "Sports Participation Highlights", Category = "sports", Number = 6 },
    new() { Path = "/images/gallery2/7.jpeg", Name = "Student Activities Showcase", Category = "events", Number = 7 },
    new() { Path = "/images/gallery2/8.jpeg", Name = "Learning Environment Display", Category = "academic", Number = 8 },
    new() { Path = "/images/gallery2/9.jpeg", Name = "School Facilities Overview", Category = "facilities", Number = 9 },
    new() { Path = "/images/gallery2/10.jpeg", Name = "Academic Performance Board", Category = "academic", Number = 10 },

    new() { Path = "/images/gallery2/11.jpeg", Name = "Admissions Promotion 2023", Category = "admissions", Number = 11 },
    new() { Path = "/images/gallery2/12.jpeg", Name = "Technology Showcase", Category = "events", Number = 12 },
    new() { Path = "/images/gallery2/13.jpeg", Name = "Student Success Highlights", Category = "academic", Number = 13 },
    new() { Path = "/images/gallery2/14.jpeg", Name = "Campus Branding Display", Category = "general", Number = 14 },
    new() { Path = "/images/gallery2/15.jpeg", Name = "College Admission Announcement", Category = "admissions", Number = 15 },

    new() { Path = "/images/gallery2/16.jpeg", Name = "Digital Learning Promotion", Category = "academic", Number = 16 },
    new() { Path = "/images/gallery2/17.jpeg", Name = "Admission Information", Category = "admissions", Number = 17 },
    new() { Path = "/images/gallery2/18.jpeg", Name = "School Logo Display", Category = "general", Number = 18 },
    new() { Path = "/images/gallery2/19.jpeg", Name = "Technology Event", Category = "events", Number = 19 },
    new() { Path = "/images/gallery2/20.jpeg", Name = "Emirates Partnership", Category = "admissions", Number = 20 },

    new() { Path = "/images/gallery2/21.jpeg", Name = "Mobile Technology Display", Category = "events", Number = 21 },
    new() { Path = "/images/gallery2/22.jpeg", Name = "Smartphone Exhibition", Category = "events", Number = 22 },
    new() { Path = "/images/gallery2/23.jpeg", Name = "Innovation Showcase", Category = "events", Number = 23 },
    new() { Path = "/images/gallery2/24.jpeg", Name = "Student Development Program", Category = "academic", Number = 24 },
    new() { Path = "/images/gallery2/25.jpeg", Name = "Sponsor Partnerships", Category = "partnerships", Number = 25 },

    new() { Path = "/images/gallery2/26.jpeg", Name = "Learning Resources Display", Category = "academic", Number = 26 },
    new() { Path = "/images/gallery2/27.jpeg", Name = "School Achievement Board", Category = "academic", Number = 27 },
    new() { Path = "/images/gallery2/28.jpeg", Name = "Admission & Technology Event", Category = "admissions", Number = 28 },
    new() { Path = "/images/gallery2/29.jpeg", Name = "Campus Life Moments", Category = "events", Number = 29 },
    new() { Path = "/images/gallery2/30.jpeg", Name = "Student Leadership Display", Category = "academic", Number = 30 },

    new() { Path = "/images/gallery2/31.jpeg", Name = "Academic Excellence Board", Category = "academic", Number = 31 },
    new() { Path = "/images/gallery2/32.jpeg", Name = "Career Guidance Promotion", Category = "academic", Number = 32 },
    new() { Path = "/images/gallery2/33.jpeg", Name = "Educational Technology Display", Category = "events", Number = 33 },
    new() { Path = "/images/gallery2/34.jpeg", Name = "School Community Engagement", Category = "events", Number = 34 },
    new() { Path = "/images/gallery2/35.jpeg", Name = "Learning Environment Promotion", Category = "academic", Number = 35 },

    new() { Path = "/images/gallery2/36.jpeg", Name = "School Values Display", Category = "general", Number = 36 },
    new() { Path = "/images/gallery2/37.jpeg", Name = "Modern Classroom Facilities", Category = "facilities", Number = 37 },
    new() { Path = "/images/gallery2/38.jpeg", Name = "Student Support Services", Category = "academic", Number = 38 },
    new() { Path = "/images/gallery2/39.jpeg", Name = "Campus Safety Information", Category = "general", Number = 39 },
    new() { Path = "/images/gallery2/40.jpeg", Name = "Academic Resources Overview", Category = "academic", Number = 40 },

    new() { Path = "/images/gallery2/41.jpeg", Name = "School Infrastructure Display", Category = "facilities", Number = 41 },
    new() { Path = "/images/gallery2/42.jpeg", Name = "Educational Excellence Promotion", Category = "academic", Number = 42 },
    new() { Path = "/images/gallery2/43.jpeg", Name = "School Innovation Highlights", Category = "events", Number = 43 },
    new() { Path = "/images/gallery2/44.jpeg", Name = "Student Achievement Showcase", Category = "academic", Number = 44 },
    new() { Path = "/images/gallery2/45.jpeg", Name = "Greenlane College Overview", Category = "general", Number = 45 }


    };
    }

    public class GalleryImageInfo
    {
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
