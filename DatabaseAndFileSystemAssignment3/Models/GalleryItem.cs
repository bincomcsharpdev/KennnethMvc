namespace DatabaseAndFileSystemAssignment3.Models
{
    public class GalleryItem
    {
        //public int Id { get; set; }
        //public string Title { get; set; } 
        //public string ImagePath { get; set; } 
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
