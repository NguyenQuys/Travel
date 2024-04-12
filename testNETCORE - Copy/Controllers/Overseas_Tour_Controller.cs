using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Overseas_Tour_Controller : Controller
    {
        private readonly JustTravelContext _context;

        public Overseas_Tour_Controller(JustTravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var OTCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var OTOverseas_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory == 2).OrderBy(m=>m.StartDate).ToListAsync();
            var viewModel = new Overseas_Tour_ViewModel
            {
                NavigationBarList = OTCNavigationBar_Controller,
                TourList = OTOverseas_Tour_Controller
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Detail(string slug, string id)
        {
            int kiemTra = 0;
            var users = new User();
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var DTDetail_Controller = await _context.Tours.Where(m => m.Hide == false && m.Link == slug && m.IdTour == id).ToListAsync();
            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber.ToString() == phoneNumer.ToString());
                    kiemTra = 1;
                }
            }
            var viewModel = new UserViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTDetail_Controller,
                kiemTraDangNhap = kiemTra,
                Register = users

            };
            return View(viewModel);
        }
    }
}
