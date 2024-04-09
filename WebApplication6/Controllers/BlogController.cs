using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using WebApplication6.Models;
using WebApplication6.ViewModal;

namespace WebApplication6.Controllers
{
    public class BlogController : Controller
    {

        private readonly MyBlogContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(MyBlogContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            var listBlog = _context.Posts.ToList();
            var viewModal = new HomeViewModal()
            {
                Postlist = listBlog,
            };
            return View(viewModal);
        }

        [HttpGet] // Thêm thuộc tính này để chỉ ra rằng hành động chỉ nhận yêu cầu HTTP GET
        public IActionResult Create()
        {
            return View(); // Trả về view để hiển thị form
        }

        [HttpPost]
        public IActionResult Create(Post post) // Sử dụng tham số post để lấy dữ liệu từ form
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của dữ liệu
            {

                _context.Posts.Add(post); // Thêm bài viết mới vào cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi

                return RedirectToAction("Index"); // Chuyển hướng đến hành động Index để hiển thị lại danh sách bài viết
            }

            return View(post); // Trả về lại view Create với dữ liệu người dùng đã nhập (để hiển thị thông báo lỗi)
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage(List<IFormFile> files)
        {
            List<string> fileUrls = new List<string>();

            foreach (IFormFile photo in Request.Form.Files)
            {
                try
                {
                    string serverMapPath = Path.Combine(_env.WebRootPath, "Image", photo.FileName);
                    using (var stream = new FileStream(serverMapPath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }
                    string fileUrl = "http://localhost:5068/Image/" + photo.FileName;
                    fileUrls.Add(fileUrl);
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có bất kỳ vấn đề nào xảy ra trong quá trình sao chép file
                    // Ví dụ: Log ngoại lệ, thông báo lỗi, vv.
                    return BadRequest("An error occurred while uploading files: " + ex.Message);
                }
            }

            // Trả về mảng chứa đường dẫn URL của tất cả các file đã được tải lên
            return Json(new { urls = fileUrls });
        }


    }
}
