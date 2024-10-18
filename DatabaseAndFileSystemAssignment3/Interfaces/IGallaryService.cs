using DatabaseAndFileSystemAssignment3.Models;

namespace DatabaseAndFileSystemAssignment3.Interfaces
{
    public interface IGallaryService
    {
        Task<GalleryItem> UploadImageAsync(IFormFile imageFile, string title);
        Task<List<GalleryItem>> GetAllGalleryItemsAsync();
    }
}
