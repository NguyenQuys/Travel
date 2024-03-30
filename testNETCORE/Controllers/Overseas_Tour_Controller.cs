using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
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
            var OTOverseas_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory == 2).ToListAsync();
            var viewModel = new Overseas_Tour_ViewModel
            {
                NavigationBarList = OTCNavigationBar_Controller,
                TourList = OTOverseas_Tour_Controller
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _NavigationBar()
        {
            return PartialView();
        }

        // GET: Overseas_Tour_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Overseas_Tour_Controller/Create
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

        // GET: Overseas_Tour_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Overseas_Tour_Controller/Edit/5
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

        // GET: Overseas_Tour_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Overseas_Tour_Controller/Delete/5
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
