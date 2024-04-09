using Admin.Models;
using Admin.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourRepository _tourRepository;
        public HomeController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        //Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var tour = await _tourRepository.GetAllAsync();
            return View(tour);
        }
    }
}
