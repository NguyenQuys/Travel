using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;

namespace testNETCORE.Controllers
{
    public class Payment_ConfirmationController : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Payment_ConfirmationController(_63tinhThanhContext context)
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

            var idTourDaDat = await _context.Invoices
                .Where(m => m.IdUser == users.IdUser)
                .Select(m => m.IdTour)
                .ToListAsync(); // lay kieu string. Vi du: DT001,DT002

            if (idTourDaDat.Count == 0)
            {
                ViewData["EmptyLike"] = "Hiện tại bạn chưa thêm Tour nào vào mục yêu thích";
            }

            // Lấy danh sách các tour mà người dùng đã thích
            var paidTourDetails = await _context.Invoices
                .Where(i => idTourDaDat.Contains(i.IdTour))
                .Join(
                    _context.Tours,
                    invoice => invoice.IdTour,
                    tour => tour.IdTour,
                    (invoice, tour) => new InfoHistoryPayment
                    {
                        TourName = tour.TourName,
                        Time = invoice.Time,
                        Amount = invoice.Amount,
                        IdOrder = invoice.IdOrder,
                    }
                ).OrderByDescending(m=>m.Time)
                .ToListAsync();
            //Tương đương đoạn code sql
            //SELECT t.Tour_Name AS TourName, i.Time, i.Amount
            //FROM Invoice i
            //JOIN Tour t ON i.ID_Tour = t.ID_Tour
            //WHERE i.ID_Tour IN('DT001')

            var LCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var invoiceController = await _context.Invoices.ToListAsync();
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
            string amountString = MomoPaymentController.soTienTransferFromMoMo;
            decimal amountDouble = decimal.Parse(amountString);

            
            Invoice newInvoice = new Invoice();
            newInvoice.IdOrder = MomoPaymentController.codeThanhToanTransferFromMoMo;
            newInvoice.IdUser = users.IdUser;
            newInvoice.Amount = amountDouble;
            newInvoice.IdTour = MomoPaymentController.idTourTransferFromMoMo;
            newInvoice.Time = DateTime.Now;
            _context.Add(newInvoice);
            _context.SaveChangesAsync();

            ViewData["CustumerName"] = User_Controller.name;
            ViewData["Amount"] = amountDouble.ToString("N0");
            ViewData["IDOrder"] = MomoPaymentController.codeThanhToanTransferFromMoMo;
            ViewData["Time"] = DateTime.Now;
            //ViewData["test"] = MomoPaymentController.payurlTEst;
            return View();
        }
    }
}
