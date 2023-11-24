using Microsoft.AspNetCore.Mvc;
using Pustok_Crud2.DAL;
using Pustok_Crud2.Extentions;
using Pustok_Crud2.Models;

namespace Pustok_Crud2.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeatureController : Controller
    {
        

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public FeatureController(AppDbContext Context, IWebHostEnvironment environment)
        {
            _context = Context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            List<Feature> features =_context.Features.ToList();
            return View(features);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            if(ModelState.IsValid)
            {

                return View();
            }
            if (feature.FileImage != null)
            {
                if (feature.FileImage.ContentType != "image/jpeg" && feature.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "File must be .png or ,jpeg(.jpg)");
                    return View(feature);

                }
                if (feature.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("FileImage", "File size must be lower than 2mb");
                    return View(feature);
                }
                feature.Image = Helper.SaveFile(_environment.WebRootPath, "uploads/sliders", feature.FileImage);
            }
            else
            {
                ModelState.AddModelError("FileImage", "Required");
                return View(feature);
            }
            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Feature wantedfeature= _context.Features.FirstOrDefault(s=>s.Id==id);
            if (wantedfeature == null)
            {
                return NotFound();
            }
            return View(wantedfeature);
        }
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            Feature existfeature= _context.Features.FirstOrDefault(s=>s.Id == feature.Id);
            if (existfeature == null)
            {
                return NotFound();
            }
            if (feature.FileImage != null)
            {
                if (feature.FileImage.ContentType != "image/jpeg" && feature.FileImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("FileImage", "File must be .png or ,jpeg(.jpg)");
                    return View(feature);

                }
                if (feature.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("FileImage", "File size must be lower than 2mb");
                    return View(feature);
                }
                string deletePath = Path.Combine(_environment.WebRootPath, "uploads/Sliders", existfeature.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                existfeature.Image = Helper.SaveFile(_environment.WebRootPath, "uploads/Sliders", feature.FileImage);


            }

            existfeature.Title= feature.Title;
            existfeature.Description= feature.Description;
            existfeature.Icon= feature.Icon;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Feature wantedfeature = _context.Features.FirstOrDefault(s => s.Id == id);
            return View(wantedfeature);
        }
        [HttpPost]
        public IActionResult Delete(Feature feature)
        {
            Feature existfeature= _context.Features.FirstOrDefault(f=>f.Id==feature.Id);
            if (existfeature == null)
            {
                return NotFound();
            }
            _context.Features.Remove(existfeature);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
