using Microsoft.AspNetCore.Mvc;
using testNETCORE.Models;

namespace testNETCORE.Controllers
{
    public class Payment_Confirmation : Controller
    {
        private readonly _63tinhThanhContext _context;
        public Payment_Confirmation(_63tinhThanhContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            return View();
        }
    }
}
