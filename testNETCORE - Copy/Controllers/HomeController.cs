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
