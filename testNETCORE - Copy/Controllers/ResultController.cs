using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class ResultController : Controller
    {
        private readonly _63tinhThanhContext _context;
        public ResultController(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string departurePlace, string destinationPlace)
        {
            ViewData["destination"] = destinationPlace;
            var RCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var RCFind_Controller = await _context.Tours.Where(m => m.Hide == false && (m.Destination1==destinationPlace||m.Destination2==destinationPlace||m.Destination3==destinationPlace))
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
