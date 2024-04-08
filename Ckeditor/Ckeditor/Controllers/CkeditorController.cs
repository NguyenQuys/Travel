using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace Ckeditor.Controllers
{
    public class CkeditorController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public CkeditorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Editor()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach (IFormFile photo in files)
            {
                string serverMapPath = Path.Combine(_env.WebRootPath, "Image", photo.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
                filepath = "http://localhost:5073/" + "Image/" + photo.FileName;
            }
            return Json(new { url = filepath });
        }

    }
}
