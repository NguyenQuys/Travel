using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var DTCDomestic_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory==1).ToListAsync();
            var viewModel = new Domestic_Tour_ViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTCDomestic_Tour_Controller,
            };
            return View(viewModel);
        }
    }
}
