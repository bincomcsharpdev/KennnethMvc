using DatabaseAndFileSystemAssignment3.Interfaces;
using DatabaseAndFileSystemAssignment3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAndFileSystemAssignment3.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGallaryService _galleryService;

        public GalleryController(IGallaryService galleryService)
        {
            _galleryService = galleryService;
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
        public async Task<IActionResult> Upload(IFormFile imageFile, string title)
        {
            if (ModelState.IsValid)
            {
                await _galleryService.UploadImageAsync(imageFile, title);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
