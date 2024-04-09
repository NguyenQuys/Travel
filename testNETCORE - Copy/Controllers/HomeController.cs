using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly _63tinhThanhContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(_63tinhThanhContext context, IWebHostEnvironment webHostEnvironment) // Thêm IWebHostEnvironment vào constructor
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; // Gán giá trị cho _webHostEnvironment
        }

        //public IActionResult Index()
        //{
        //    return View(data.Tinhs.ToList());
        //}
       
        //[HttpPost]
        //public IActionResult Index(string chosenPlace)
        //{
        //    var choosePlace = data.Tinhs.Where(a => a.Province == chosenPlace);
        //    return View(choosePlace);
        //}
        [HttpPost]
        public IActionResult UploadImage(IFormFile upload)
        {
            if(upload !=null && upload.Length > 0)
            {
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), _webHostEnvironment.WebRootPath
                    , fileName);
                var stream = new FileStream(path, FileMode.Create);
                upload.CopyToAsync(stream);
                return new JsonResult(new { path = "/uploads" + fileName });
            }
            return RedirectToAction("create");
        }
        [HttpGet]
       
        public IActionResult UploadExplorer()
        {
            var uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var dir = new DirectoryInfo(uploadsPath);
            ViewBag.fileInfo = dir.GetFiles();
            return View("FileExplorer");
        }

       
        public async Task<IActionResult> Index()
        {
            var HomeeChoosePlace_Controller = await _context.Tinhs.ToListAsync();
            var HomeNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var HomeTour_Controller = await _context.Tours.Where(m=>m.Hide==false).ToListAsync();
            var viewModel = new HomeViewModel
            {
                NavigationBarList = HomeNavigationBar_Controller,
                TinhList = HomeeChoosePlace_Controller,
                TourList = HomeTour_Controller,
            };
            return View(viewModel);
        
        }
    }
}
