using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom8_TourDuLich.Models;
using nhom8_TourDuLich.ViewModels;

namespace nhom8_TourDuLich.Controllers
{
    public class Liked_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Liked_Controller(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var LCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var LLiked_Controller = await _context.Tours.Where(m => m.Hide == false && m.Like == true).ToListAsync();
            var viewModel = new Liked_ViewModel
            {
                NavigationBarList = LCNavigationBar_Controller,
                TourList = LLiked_Controller
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Detail(string slug, string id)
        {
            var LCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var LDetail_Controller = await _context.Tours.Where(m => m.Hide == false && m.Link == slug && m.TourId == id).ToListAsync();
            if (LDetail_Controller == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error"
                };
                return View("Error", errorViewModel); // Nếu tìm ko ra thì check chỗ này
            }

            var viewModel = new Liked_ViewModel
            {
                NavigationBarList = LCNavigation_Bar_Controller,
                TourList = LDetail_Controller
            };
            return View(viewModel);
        }

        // GET: Liked_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Liked_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Liked_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Liked_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Liked_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Liked_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
