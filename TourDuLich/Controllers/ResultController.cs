using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom8_TourDuLich.Models;
using nhom8_TourDuLich.ViewModels;

namespace nhom8_TourDuLich.Controllers
{
    public class ResultController : Controller
    {
        private readonly _63tinhThanhContext _context;
        public ResultController(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string departurePlace, string destinationPlace,DateOnly checkinDay)
        {
            ViewData["destination"] = destinationPlace;
            var RCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var RCFind_Controller = await _context.Tours.Where(m => m.Hide == false && 
                (m.Destination1.Contains(destinationPlace)|| m.Destination2.Contains(destinationPlace) || m.Destination3.Contains(destinationPlace)
                ||m.Departure==departurePlace
                ||m.StartDate==checkinDay))
                .OrderBy(m => m.StartDate)
                .ToListAsync();
            var viewModel = new Result_ViewModel
            {
                NavigationBarList = RCNavigation_Bar_Controller,
                TourList = RCFind_Controller,
            };
            return View(viewModel);
        }
    }
}
