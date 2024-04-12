using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Payment_ConfirmationController : Controller
    {
        private readonly JustTravelContext _context;

        public Payment_ConfirmationController(JustTravelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() 
        {
            var users = new User();

            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber == phoneNumer);
                }
            }

            var idTourDaDat = await _context.InvoiceDetails
                .Where(m => m.IdUser == users.IdUser)
                .Select(m => m.IdTour)
                .ToListAsync(); // lay kieu string. Vi du: DT001,DT002

            //if (idTourDaDat.Count == 0)
            //{
            //    ViewData["EmptyLike"] = "Hiện tại bạn chưa thêm Tour nào vào mục yêu thích";
            //}

            // Lấy danh sách các tour mà người dùng đã thích
            var paidTourDetails = await _context.InvoiceDetails
                .Where(i => idTourDaDat.Contains(i.IdTour))
                .Join(
                    _context.Tours,
                    invoice => invoice.IdTour,
                    tour => tour.IdTour,
                    (invoice, tour) => new InfoHistoryPayment
                    {
                        TourName = tour.TourName,
                        Time =(DateTime) invoice.InvoiceDate, // sua o day
                        Price = invoice.Price,
                        IdOrder = invoice.IdInvoice,
                    }
                ).OrderByDescending(m=>m.Time)
                .ToListAsync();
            //Tương đương đoạn code sql
            //SELECT t.Tour_Name AS TourName, i.Time, i.Price
            //FROM Invoice i
            //JOIN Tour t ON i.ID_Tour = t.ID_Tour
            //WHERE i.ID_Tour IN('DT001')

            var LCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var invoiceController = await _context.InvoiceDetails.ToListAsync();
            var viewModel = new Payment_Confirmation_ViewModel
            {
                NavigationBarList = LCNavigationBar_Controller,
                PaidTourList = paidTourDetails,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SuccessFul_Payment(string addTourPay)
        {
            var users = new User();

            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber == phoneNumer);
                }
            }
            string PriceString = MomoPaymentController.soTienTransferFromMoMo;
            decimal PriceDouble = decimal.Parse(PriceString);

            
            InvoiceDetail newInvoice = new InvoiceDetail();
            newInvoice.IdInvoice = MomoPaymentController.codeThanhToanTransferFromMoMo;
            newInvoice.IdUser = users.IdUser;
            newInvoice.Price = PriceDouble;
            newInvoice.IdTour = MomoPaymentController.idTourTransferFromMoMo;
            newInvoice.InvoiceDate = DateTime.Now;
            _context.Add(newInvoice);
            _context.SaveChangesAsync();

            ViewData["CustumerName"] = User_Controller.name;
            ViewData["Price"] = PriceDouble.ToString("N0");
            ViewData["IDOrder"] = MomoPaymentController.codeThanhToanTransferFromMoMo;
            ViewData["Time"] = DateTime.Now;
            //ViewData["test"] = MomoPaymentController.payurlTEst;
            return View();
        }
    }
}
