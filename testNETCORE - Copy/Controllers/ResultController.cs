using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class ResultController : Controller
    {
        private readonly JustTravelContext _context;
        public ResultController(JustTravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string departurePlace, string destinationPlace,DateOnly checkinDay)
        {
            ViewData["destination"] = destinationPlace;
            var RCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var RCFind_Controller = await _context.Tours.Where(m => m.Hide == false && 
                (m.Destination1.Contains(destinationPlace)|| m.Destination2.Contains(destinationPlace) || m.Destination3.Contains(destinationPlace)
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
