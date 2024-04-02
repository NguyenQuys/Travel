using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Information_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Information_Controller(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ICNavigationBar = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new Information_ViewModel
            {
                NavigationBarList = ICNavigationBar,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _NavigationBar()
        {
            return PartialView();
        }

        // GET: Information_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Information_Controller/Create
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

        // GET: Information_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Information_Controller/Edit/5
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

        // GET: Information_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Information_Controller/Delete/5
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
