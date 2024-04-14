using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Filters;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [ServiceFilter(typeof(AdminAuthorizationFilter))] // Sử dụng bộ lọc AdminAuthorizationFilter

    public class HomeAdminController : Controller
    {
        private readonly JustTravelContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeAdminController(JustTravelContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Route("")] //Tạo đường dẫn mặc định
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var tourTrongNuoc = await _context.Tours.Where(m => m.Hide == false && m.Idcategory == 1).OrderBy(m => m.StartDate).ToListAsync();
            var tourNgoaiNuoc = await _context.Tours.Where(m => m.Hide == false && m.Idcategory == 2).OrderBy(m => m.StartDate).ToListAsync();
            var viewModel = new AdminModalViews.Admin_AddTour
            {
                TourTrongNuoc = tourTrongNuoc,
                TourNgoaiNuoc = tourNgoaiNuoc,
            };
            return View(viewModel);
        }

        [Route("Update")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [Route("Update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Tour id)
        {
            _context.Update(id);
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "HomeAdmin");
        }

        [Route("AddTour")]
        [HttpGet]
        public async Task<IActionResult> AddTour()
        {
            ViewBag.Idcategory = new SelectList(_context.Tours, "ID_Category","CategoryName");
            return View();
        }

        [Route("AddTour")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTour(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                _context.Tours.Add(tour);
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UploadImage")]
        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach (IFormFile photo in Request.Form.Files)
            {
                string fileName = photo.FileName;
                string directoryPath = Path.Combine(_env.WebRootPath, "images");

                // Ensure directory existence
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, fileName);

                try
                {
                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }

                    // Construct the URL for the uploaded image
                    filepath = "https://localhost:7067/images/" + fileName;
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    Console.WriteLine("Error saving file: " + ex.Message);
                }
            }

            // Trả về URL của hình ảnh cho CKEditor
            return Json(new { url = filepath });
        }



    }
}





