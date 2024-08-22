using ConversionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace ConversionMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            using (MemoryStream stream = new MemoryStream())
            {
                image.CopyTo(stream);
                var imageData = stream.ToArray();

                return File(imageData, "image/jpeg", "image.jpg");
            }
        }
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
