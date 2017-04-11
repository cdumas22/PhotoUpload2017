using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoUpload.ViewModels;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PhotoUpload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                //save the image somewhere
                //await Service.Update(model.CropInformation);
                using (Image image = Image.FromStream(new MemoryStream(model.CropInformation.Bytes)))
                {
                    image.Save("wwwroot/images/output.jpg", ImageFormat.Jpeg);  // Or Png
                    model.ImageDataUrl = "/images/output.jpg";
                }
            }

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
