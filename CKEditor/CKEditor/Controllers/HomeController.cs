using CKEditor.Models;
using CKEditor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace CKEditor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var content = _context.Content.ToList();
            var viewModels = new HomeViewModel
            {
                Contents = content,
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddCKeditor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCKeditor(Content model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach (IFormFile photo in Request.Form.Files)
            {
                string serverMapPath = Path.Combine(_env.WebRootPath, "images", photo.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath = "https://localhost:7034/" + "images/" + photo.FileName;
            }
            return Json(new { url = filepath });
        }
    }
}
