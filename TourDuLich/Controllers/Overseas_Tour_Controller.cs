using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom8_TourDuLich.Models;
using nhom8_TourDuLich.ViewModels;

namespace nhom8_TourDuLich.Controllers
{
    public class Overseas_Tour_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Overseas_Tour_Controller(_63tinhThanhContext context)
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
            User getDataFromUser = TempData["transfer"] as User;
            var users = new User();
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var DTDetail_Controller = await _context.Tours.Where(m => m.Hide == false && m.Link == slug && m.TourId == id).ToListAsync();
            //if(DTDetail_Controller == null)
            //{
            //    var errorViewModel = new ErrorViewModel
            //    {
            //        RequestId = "Product Error"
            //    };
            //    return View("Error", errorViewModel); // Nếu tìm ko ra thì check chỗ này
            //}
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
