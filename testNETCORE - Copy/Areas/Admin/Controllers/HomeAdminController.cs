using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Areas.Admin.Controllers.AdminModalViews;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly JustTravelContext _context;

        public HomeAdminController(JustTravelContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var tourTrongNuoc = await _context.Tours.Where(m => m.Hide == false && m.IdCategory == 1).OrderBy(m => m.StartDate).ToListAsync();
            var tourNgoaiNuoc = await _context.Tours.Where(m => m.Hide == false && m.IdCategory == 2).OrderBy(m => m.StartDate).ToListAsync();
            var viewModel = new Admin_Domestic_Tour
            {
                TourTrongNuoc = tourTrongNuoc,
                TourNgoaiNuoc = tourNgoaiNuoc,
            };
            return View(viewModel);
        }
        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [HttpPost("Update/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, Tour updatedTour)
        {
            if (id != updatedTour.IdTour)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(updatedTour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(updatedTour);
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            // Remove the tour from your data store
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("List-Domestic-Tour")]
        public async Task<IActionResult> List_Domestic_Tour()
        {
            var DTCDomestic_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.IdCategory == 1).OrderBy(m => m.StartDate).ToListAsync();
            var viewModel = new Domestic_Tour_ViewModel
            {
                TourList = DTCDomestic_Tour_Controller,
            };
            return View(viewModel);
        }
    }
}




