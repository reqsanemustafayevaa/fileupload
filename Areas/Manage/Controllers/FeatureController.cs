using Microsoft.AspNetCore.Mvc;
using Pustok_Crud2.DAL;
using Pustok_Crud2.Models;

namespace Pustok_Crud2.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class FeatureController : Controller
    {
        

        private readonly AppDbContext _context;
        public FeatureController(AppDbContext Context)
        {
            _context = Context;
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
