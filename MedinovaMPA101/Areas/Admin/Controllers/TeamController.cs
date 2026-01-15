using MedinovaMPA101.Contexts;
using MedinovaMPA101.ViewModels.TeamViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedinovaMPA101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _folderPath;

        public TeamController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _folderPath = Path.Combine(_environment.WebRootPath, "assets", "img");
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams.Select(x=>new TeamGetVM()
            {
                Id=x.Id,
                ImagePath=x.ImagePath,
                Name=x.Name,
                Position = x.Position,
                Description =x.Description,
            }).ToListAsync();
            return View(teams);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var teams = await _context.Teams.Select(x => new TeamGetVM()
            //{
            //    Id = x.Id,
            //    ImagePath = x.ImagePath,
            //    Name = x.Name,
            //    Position = x.Position,
            //    Description = x.Description,
            //}).ToListAsync();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


        }

    }
}
