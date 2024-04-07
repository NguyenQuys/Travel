using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoMo;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Plugins;
using nhom8_TourDuLich.Models;
using nhom8_TourDuLich.ViewModels;
using ThanhToanMoMo.Others;

namespace nhom8_TourDuLich.Controllers
{
    public class Domestic_Tour_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Domestic_Tour_Controller(_63tinhThanhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m=>m.Hide==false).OrderBy(m=>m.Order).ToListAsync();
            var DTCDomestic_Tour_Controller = await _context.Tours.Where(m => m.Hide == false && m.Idcategory==1).OrderBy(m=>m.StartDate).ToListAsync();
            var viewModel = new Domestic_Tour_ViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTCDomestic_Tour_Controller,
            };
            return View(viewModel);
        }

        public async Task<ActionResult> Payment(int totalMOMO)
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Thanh toán online";
            string returnUrl = "https://localhost:7067/";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = totalMOMO.ToString();
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount",amount},
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        public async Task<IActionResult> Detail(string slug,string id)
        {
            int kiemTra = 0;
            User getDataFromUser = TempData["transfer"] as User;
            var users = new User();
            var DTCNavigation_Bar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var DTDetail_Controller = await _context.Tours.Where(m => m.Hide == false && m.Link == slug && m.TourId==id).ToListAsync();
            //if(DTDetail_Controller == null)
            //{
            //    var errorViewModel = new ErrorViewModel
            //    {
            //        RequestId = "Product Error"
            //    };
            //    return View("Error", errorViewModel); // Nếu tìm ko ra thì check chỗ này
            //}
            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber.ToString() == phoneNumer.ToString());
                    kiemTra = 1;
                }
            }
            var viewModel = new UserViewModel
            {
                NavigationBarList = DTCNavigation_Bar_Controller,
                TourList = DTDetail_Controller,
                kiemTraDangNhap = kiemTra,
                Register = users
                
            };
            return View(viewModel);
        }
    }
}
