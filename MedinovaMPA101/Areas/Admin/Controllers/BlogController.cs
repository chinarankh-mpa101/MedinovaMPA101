using MedinovaMPA101.Contexts;
using MedinovaMPA101.Models;
using MedinovaMPA101.ViewModels.BlogViewModels;
using MedinovaMPA101.ViewModels.TeamViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MedinovaMPA101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _folderPath;

        public BlogController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _folderPath = Path.Combine(_environment.WebRootPath, "assets", "img");
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _context.Blogs.Select(x=>new BlogGetVM()
            {
                Id=x.Id,
                Text=x.Text,
                Description=x.Description,
                ImagePath=x.ImagePath,
                TeamName=x.Team.Name
            }).ToListAsync();
            return View(teams);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teams = await _context.Teams.Select(x => new SelectListItem()
            {
               Value=x.Id.ToString(),
               Text=x.Name
            }).ToListAsync();
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            var teams = await _context.Teams.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();
            ViewBag.Teams = teams;
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var isExistTeam = await _context.Teams.AnyAsync(x => x.Id == vm.TeamId);
            if (!isExistTeam)
            {
                ModelState.AddModelError("TeamId", "Bele bir doctor movcud deyil");
                return View(vm);
            }
            if (vm.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "Image must be 2mb");
                return View(vm);
            }
            if (!vm.Image.ContentType.ToLower().Contains("image"))
            {
                ModelState.AddModelError("Image", "Image must be image format");
                return View(vm);
            }
            string uniqueFileName = Guid.NewGuid().ToString() + vm.Image.FileName;
            string path = Path.Combine(_folderPath, uniqueFileName);
            using FileStream stream = new(path, FileMode.Create);
            await vm.Image.CopyToAsync(stream);
            Blog blog = new()
            {
                ImagePath = uniqueFileName,
                Text = vm.Text,
                Description = vm.Description,
                TeamId=vm.TeamId
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var blogs = await _context.Blogs.FindAsync(id);
            if (blogs is null)
                return NotFound();
            _context.Blogs.Remove(blogs);
            await _context.SaveChangesAsync();
            string deletedImagePath = Path.Combine(_folderPath, blogs.ImagePath);
            if (System.IO.File.Exists(deletedImagePath))
                System.IO.File.Delete(deletedImagePath);
            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var blogs = await _context.Blogs.FindAsync(id);
            if (blogs is null)
                return NotFound();
            BlogUpdateVM vm = new()
            {
                Id=blogs.Id,
                Text = blogs.Text,
                Description = blogs.Description,
                TeamId=blogs.TeamId
               
            };
            var teams = await _context.Teams.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                
            }).ToListAsync();
            ViewBag.Teams = teams;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (vm.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "Image must be 2mb");
                return View(vm);
            }
            if (!vm.Image.ContentType.ToLower().Contains("image"))
            {
                ModelState.AddModelError("Image", "Image must be image format");
                return View(vm);
            }
            var isExistBlog = await _context.Blogs.FindAsync(vm.Id);
            if (isExistBlog is null)
                return BadRequest();
            isExistBlog.Text = vm.Text;
            isExistBlog.Description = vm.Description;
            isExistBlog.TeamId = vm.TeamId;

            string uniqueFileName = Guid.NewGuid().ToString() + vm.Image.FileName;
            string newPath = Path.Combine(_folderPath, uniqueFileName);
            using FileStream stream = new(newPath, FileMode.Create);
            await vm.Image.CopyToAsync(stream);

            string oldImagePath = Path.Combine(_folderPath, isExistBlog.ImagePath);

            if (System.IO.File.Exists(oldImagePath))
                System.IO.File.Delete(oldImagePath);
            isExistBlog.ImagePath = uniqueFileName;
            _context.Blogs.Update(isExistBlog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

    }

}
