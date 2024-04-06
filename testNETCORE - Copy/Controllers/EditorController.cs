using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;

namespace testNETCORE.Controllers
{
    public class EditorController : Controller
    {
        private readonly _63tinhThanhContext _context;

        public EditorController(_63tinhThanhContext context)
        {
            _context = context;
        }

        public List<NavigationBar> NavigationBarList { get; private set; }

        public async Task<IActionResult> Editor()
        {
            var OTCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            NavigationBarList = OTCNavigationBar_Controller;
            return View();
        }
    }
}
