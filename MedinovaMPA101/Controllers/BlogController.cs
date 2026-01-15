using Microsoft.AspNetCore.Mvc;

namespace MedinovaMPA101.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
