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
