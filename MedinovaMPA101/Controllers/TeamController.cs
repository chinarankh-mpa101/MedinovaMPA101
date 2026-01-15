using Microsoft.AspNetCore.Mvc;

namespace MedinovaMPA101.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
