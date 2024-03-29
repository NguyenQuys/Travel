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

        public HomeController(_63tinhThanhContext context)
        {
            _context = context;
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

        public async Task<IActionResult> Index()
        {
            var HomeNavigationBar = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            //var hutechBar1 = await _context.NavigationBars.Where(m => m.Hide == false).FirstOrDefaultAsync();
            var viewModel = new HomeViewModels
            {
                navigationBars = HomeNavigationBar
                //hutechBar = hutechBar1,
            };
            return View(viewModel);
        }

        public IActionResult Liked()
        {
            return View();
        }

        public IActionResult Travel_Guide()
        {
            return View();
        }

        public IActionResult Domestic_Tour()
        {
            return View();
        }

        public IActionResult Overseas_Tour()
        {
            return View();
        }

        public async Task<IActionResult> _NavigationBar()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
