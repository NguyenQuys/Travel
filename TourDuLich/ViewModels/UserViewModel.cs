using nhom8_TourDuLich.Models;

namespace nhom8_TourDuLich.ViewModels
{
    public class UserViewModel
    {
        public List<NavigationBar> NavigationBarList { get; set; }
        public User Register { get; set; }
        public List<Tour> TourList { get; set; }

        public int kiemTraDangNhap {  get; set; }
        public int giaTien = 0;

        public UserViewModel() 
        {
            Register = new User();
        }

    }
}
