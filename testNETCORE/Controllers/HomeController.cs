using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testNETCORE.Models;

namespace testNETCORE.Controllers
{
    public class HomeController : Controller
    {
        _63tinhThanhContext data = new _63tinhThanhContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(data.Tinhs.ToList());
        }

        [HttpPost]
        public IActionResult Index(string chosenPlace)
        {
            var choosePlace = data.Tinhs.Where(a => a.Province == chosenPlace);
            return View(choosePlace);
        }

        public IActionResult Liked()
        {
            return View();
        }

        public IActionResult Travel_Guide()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
