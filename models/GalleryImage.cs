namespace Greenlane.models
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }

    public class GalleryVideo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}