using Microsoft.AspNetCore.Mvc;

namespace Pustok_Crud2.Areas.Manage.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
