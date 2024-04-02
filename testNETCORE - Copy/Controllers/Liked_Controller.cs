using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
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
            var LCNavigationBar = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new Liked_ViewModel
            {
                NavigationBarList = LCNavigationBar,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _NavigationBar()
        {
            return PartialView();
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
