using DatabaseAndFileSystemAssignment3.Interfaces;
using DatabaseAndFileSystemAssignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAndFileSystemAssignment3.Repository
{
    public class GalleryService : IGallaryService
    {
        private readonly AppDbContext _dbContext;

        public GalleryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<GalleryItem>> GetAllGalleryItemsAsync()
        {
            return await _dbContext.Kenneths.ToListAsync();
        }

        public async Task<GalleryItem> UploadImageAsync(IFormFile imageFile, string title)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid image file");
            }

            // Generate a unique filename and save the image
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            // Save the image to the wwwroot/images folder
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Create a new gallery item
            var newGalleryItem = new GalleryItem
            {
                Title = title,
                ImagePath = "/images/" + fileName,
                UploadDate = DateTime.Now
            };

            // Save to the database
            _dbContext.Kenneths.Add(newGalleryItem);
            await _dbContext.SaveChangesAsync();

            return newGalleryItem;
        }
    }
}
