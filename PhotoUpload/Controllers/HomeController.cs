using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoUpload.ViewModels;

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
            //if (ModelState.IsValid)
            //{
            //    //save the image somewhere
            //    //await Service.Update(model.CropInformation);

            //    return RedirectToAction(nameof(Contact));
            //}
            
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
