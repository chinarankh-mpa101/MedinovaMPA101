using System.Diagnostics;
using MedinovaMPA101.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedinovaMPA101.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="Member")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
