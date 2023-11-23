using Microsoft.AspNetCore.Mvc;

namespace Pustok_Crud2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
