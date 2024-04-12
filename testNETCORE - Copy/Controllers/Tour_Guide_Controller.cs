using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Tour_Guide_Controller : Controller
    {
        private readonly JustTravelContext _context;

        public Tour_Guide_Controller(JustTravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var TGNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var TGTour_Guide_Controller = await _context.TravelGuides.Where(m => m.Hide == false).ToListAsync();
            var viewModel = new Tour_Guide_ViewModel
            {
                NavigationBarList = TGNavigationBar_Controller,
                TravelGuideList = TGTour_Guide_Controller,
            };
            return View(viewModel);
        }
    }
}
