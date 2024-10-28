using DatabaseAndFileSystemAssignment3.Models;

namespace DatabaseAndFileSystemAssignment3.Interfaces
{
    public interface IGallaryService
    {
        Task<GalleryItem> UploadImageAsync(IFormFile imageFile, string title, string description);
        Task<List<GalleryItem>> GetAllGalleryItemsAsync();
    }
}
