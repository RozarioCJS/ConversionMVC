using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConversionMVC.Models
{
    public class ImageTypeViewModel
    {
        public string ImageType { get; set; }
        public List<SelectListItem> ImageTypes { get; set; }
    }
}
