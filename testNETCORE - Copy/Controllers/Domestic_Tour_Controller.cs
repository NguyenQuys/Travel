using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Domestic_Tour_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Domestic_Tour_Controller(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m=>m.Hide==false).OrderBy(m=>m.Order).ToListAsync();
            var DTCDomestic_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory==1).OrderBy(m=>m.StartDate).ToListAsync();
            var viewModel = new Domestic_Tour_ViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTCDomestic_Tour_Controller,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Detail(string slug, string id)
        {
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var DTDetail_Controller = await _context.Tours.Where(m => m.Hide == false && m.Link == slug && m.TourId == id).ToListAsync();
            if(DTDetail_Controller == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error"
                };
                return View("Error", errorViewModel); // Nếu tìm ko ra thì check chỗ này
            }

            var viewModel = new Domestic_Tour_ViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTDetail_Controller
            };
            return View(viewModel);
        }
    }
}
