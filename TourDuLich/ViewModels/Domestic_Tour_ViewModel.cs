using nhom8_TourDuLich.Models;

namespace nhom8_TourDuLich.ViewModels
{
    public class Domestic_Tour_ViewModel
    {
        public List<NavigationBar> NavigationBarList { get; set; }

        public List<Tour> TourList { get; set; }
        public User Register { get; set; }
        public Domestic_Tour_ViewModel()
        {
            Register = new User();
        }
    }
}
