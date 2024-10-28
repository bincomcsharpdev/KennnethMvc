using DatabaseAndFileSystemAssignment3.Interfaces;
using DatabaseAndFileSystemAssignment3.Models;
using DatabaseAndFileSystemAssignment3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAndFileSystemAssignment3.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGallaryService _galleryService;
        private readonly AppDbContext dbContext;

        public GalleryController(IGallaryService galleryService, AppDbContext dbContext)
        {
            _galleryService = galleryService;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var galleryItems = await _galleryService.GetAllGalleryItemsAsync();
            return View(galleryItems);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile, string title, string description)
        {
            if (ModelState.IsValid)
            {
                await _galleryService.UploadImageAsync(imageFile, title, description);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult GetImage(int id)
        {
            var photo = dbContext.Kenneth_GalleryItems.Find(id);
            if (photo != null)
            {
                return File(photo.ImageData, photo.ImageMimeType);
            }
            return null;
        }
    }
}
