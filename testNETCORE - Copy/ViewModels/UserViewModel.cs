using testNETCORE.Models;

namespace testNETCORE.ViewModels
{
    public class UserViewModel
    {
        public List<NavigationBar> NavigationBarList { get; set; }
        public User Register { get; set; }
        public List<Tour> TourList { get; set; }


        public UserViewModel() 
        {
            Register = new User();
        }

    }
}
