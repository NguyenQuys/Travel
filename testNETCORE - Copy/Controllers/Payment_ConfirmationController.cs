using Microsoft.AspNetCore.Mvc;
using testNETCORE.Models;

namespace testNETCORE.Controllers
{
    public class Payment_ConfirmationController : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Payment_ConfirmationController(_63tinhThanhContext context)
        {
            _context = context;
        }

        public IActionResult SuccessFul_Payment()
        {
            ViewData["test"] = Domestic_Tour_Controller.codeThanhToan;
            // Sử dụng biến codeThanhToan ở đây
            return View();
        }
    }
}
