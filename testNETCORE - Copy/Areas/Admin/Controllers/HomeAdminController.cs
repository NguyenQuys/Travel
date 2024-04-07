using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Areas.Admin.Controllers.AdminModalViews;
using testNETCORE.Controllers;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly _63tinhThanhContext _context;

        public HomeAdminController(_63tinhThanhContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("List-Domestic-Tour")]
        public async Task<IActionResult> List_Domestic_Tour()
        {
            var DTCDomestic_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory == 1).OrderBy(m => m.StartDate).ToListAsync();
            var viewModel = new Domestic_Tour_ViewModel
            {
                TourList = DTCDomestic_Tour_Controller,
            };
            return View(viewModel);
        }
    }
}




