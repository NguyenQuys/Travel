using testNETCORE.Models;

namespace testNETCORE.ViewModels
{
    public class Payment_Confirmation_ViewModel
    {
        public List<NavigationBar> NavigationBarList { get; set; }
        public List<InfoHistoryPayment> PaidTourList { get; set; }
        public int kiemTraDangNhap { get; set; }
    }
}
