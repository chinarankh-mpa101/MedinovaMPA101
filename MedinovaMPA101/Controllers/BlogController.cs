using MedinovaMPA101.Contexts;
using MedinovaMPA101.ViewModels.BlogViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedinovaMPA101.Controllers
{
    public class BlogController(AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teams = await _context.Blogs.Select(x => new BlogGetVM()
            {
                Id = x.Id,
                Text = x.Text,
                Description = x.Description,
                ImagePath = x.ImagePath,
                TeamName = x.Team.Name
            }).ToListAsync();
            return View(teams);
            
        }
    }
}
