
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Statitics_Controller : Controller
    {
        private readonly JustTravelContext _context;
        public Statitics_Controller(JustTravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var STNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            //var Price = await _context.Invoices.Where(m => m.Price > 0).ToListAsync();
            var IDtour = await _context.InvoiceDetails.Where(m => m.IdTour != null && m.Price > 0).ToListAsync();
            var viewPrice = new Statistics_ViewModel
            {
                TGNavigationBar = STNavigationBar_Controller,
                InvoiceList = IDtour,
                //TourListInvoice = Price,
            };
            return View(viewPrice);
        }
        public async Task<IActionResult> Count()
        {
            var STNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

            var IDtour = await _context.InvoiceDetails.Where(m => m.IdTour != null && m.Price > 0).ToListAsync();
            //var CountTour = await _context.Invoices.CountAsync(m => m.IdTour != null);
            var thongke = await _context.InvoiceDetails.Where(m => m.Price > 0).SumAsync(m => m.Price);
            
            if(thongke > 0)
            {
                var viewPrice = new Statistics_ViewModel
                {
                    TGNavigationBar = STNavigationBar_Controller,
                    //InvoiceList = IDtour,
                    Count = thongke,
                };
            }
            else
            {
                return NotFound();
            }
            return View(thongke);
        }   
    }
}
