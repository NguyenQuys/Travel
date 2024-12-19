using Admin.Models;
using Admin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository _tourRepositor;
        private readonly ICategoryRepository _categoryRepository;
        public TourController(ITourRepository tourRepositor, ICategoryRepository categoryRepository)
        {
            _tourRepositor = tourRepositor;
            _categoryRepository = categoryRepository;
        }
        // Hiển thị danh sách tour
        public async Task<IActionResult> Index()
        {
            var tour = await _tourRepositor.GetAllAsync();
            return View(tour);
        }
        // Hiển thị form thêm Tour
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View();
        }
        // Xử lý thêm tour
        [HttpPost]
        public async Task<IActionResult> Add(Tour tour)
        {
            if (ModelState.IsValid)
            {
                await _tourRepositor.AddAsync(tour);
                return RedirectToAction("Index");
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View(tour);
        }
        public async Task<IActionResult> Display(int id)
        {
            var tour = await _tourRepositor.GetByIdAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }
        public async Task<IActionResult> Update(int id)
        {
            var tour = await _tourRepositor.GetByIdAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName", tour.CategoryId);
            return View(tour);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Tour tour)
        {
            ModelState.Remove("ImageUrl");
            if (id != tour.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingTour = await _tourRepositor.GetByIdAsync(id);
                existingTour.TourName = tour.TourName;
                existingTour.Departure = tour.Departure;
                existingTour.Destination1 = tour.Destination1;
                existingTour.Destination2 = tour.Destination2;
                existingTour.Destination3 = tour.Destination3;
                existingTour.MaxQuantity = tour.MaxQuantity;
                existingTour.Length = tour.Length;
                existingTour.PriceForAdult = tour.PriceForAdult;
                existingTour.PriceForChildren = tour.PriceForChildren;
                existingTour.NdaysNnights = tour.NdaysNnights;
                existingTour.StartDate = tour.StartDate;
                existingTour.EndDate = tour.EndDate;
                existingTour.JourneyHightlight = tour.JourneyHightlight;
                existingTour.TravelingSchedule = tour.TravelingSchedule;
                existingTour.Description = tour.Description;
                existingTour.Link = tour.Link;
                await _tourRepositor.UpdateAsync(existingTour);
                return RedirectToAction("Index");
            }
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View(tour);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _tourRepositor.GetByIdAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tourRepositor.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
