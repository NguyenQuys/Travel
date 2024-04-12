using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class StatiticsController : Controller
    {
        private readonly _63tinhThanhContext _context;
        public StatiticsController(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {

            //if (id != null)
            //{
            //    var idtour = await _context.Invoices.Where(m => m.IdTour == id).ToListAsync();
            //}
            //else
            //{
            //    return NotFound();
            //}

            //var thongke = await _context.Invoices.CountAsync(m => m.Amount > 0);

            return View();
        }
    }
}
