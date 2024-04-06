using Microsoft.AspNetCore.Mvc;
using TourTrongNuoc.Repositories;
using TourTrongNuoc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TourTrongNuoc.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository _tourRepository;
        public TourController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
           
        }
      
        [HttpPost]
        public IActionResult Add(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _tourRepository.Add(tour);
                return RedirectToAction("Index"); // Chuyển hướng tới trang danh 
                
            }
            return View(tour);
        }

        public IActionResult Index()
        {
            var tours = _tourRepository.GetAll();
            return View(tours);
        }
        public IActionResult Display(int id)
        {
            var tour = _tourRepository.GetById(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

    }
}
