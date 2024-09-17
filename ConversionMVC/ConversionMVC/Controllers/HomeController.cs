using ConversionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace ConversionMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var model = new ImageTypeViewModel
            {
                ImageTypes = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "PNG",
                        Value = "image/png"
                    },
                    new SelectListItem
                    {
                        Text = "JPEG",
                        Value = "image/jpeg"
                    },
                    new SelectListItem
                    {
                        Text = "WEBP",
                        Value = "image/webp"
                    }
                },
                ImageType = "PNG"
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UploadImage(IFormFile image, ImageTypeViewModel model, string ImageName)
        {
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var selectedImageType = model.ImageType;

            var imageName = ImageName;
            if (imageName == null)
            {
                imageName = "Image";
            }

            switch (selectedImageType)
            {
                case "image/png":
                    imageName = imageName + ".png";
                    break;
                case "image/jpeg":
                    imageName = imageName + ".jpeg";
                    break;
                case "image/webp":
                    imageName = imageName + ".webp";
                    break;
                default:
                    imageName = imageName + ".png";
                    break;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                image.CopyTo(stream);
                var imageData = stream.ToArray();

                return File(imageData, selectedImageType, imageName);
            }
        }
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
