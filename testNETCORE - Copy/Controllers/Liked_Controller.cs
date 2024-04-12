using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using testNETCORE.Models;
using testNETCORE.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace testNETCORE.Controllers
{
    public class Liked_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;

        public Liked_Controller(_63tinhThanhContext context)
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

            // Lấy danh sách IDTour từ bảng Like của người dùng hiện tại
            var likedTours = await _context.Likes
                .Where(m => m.IdUser == users.IdUser) //IDUER 8 
                .Select(m => m.IdTour)
                .ToListAsync(); // lay kieu string. Vi du: DT001,DT002

            //if (_context.Likes.Count()==0)
            //{
            //    ViewData["EmptyLike"] = "Hiện tại bạn chưa thêm Tour nào vào mục yêu thích";
            //}

            // Lấy danh sách các tour mà người dùng đã thích
            var likedTourNames = await _context.Tours
                .Where(t => likedTours.Contains(t.IdTour))
                .ToListAsync();

            var LCNavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new Liked_ViewModel
            {
                NavigationBarList = LCNavigationBar_Controller,
                TourLikedList = likedTourNames,
                kiemTraUserID = users.IdUser
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Remove(string idTourRemove)
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

            var likedTours = await _context.Likes
                .Where(m => m.IdUser == users.IdUser)
                .Select(m => m.IdTour)
                .ToListAsync(); // lay kieu string. Vi du: DT001
            if (likedTours.Count != 0)
            {
                var RemoveTours = await _context.Likes
                        .Where(m => m.IdUser == users.IdUser) //users.id =8
                        .Select(m => m.IdTour)
                        .ToListAsync();

                var likedTourNames = await _context.Likes
                        .Where(t => RemoveTours.Contains(t.IdTour))
                        .ToListAsync();

                foreach (var tour in likedTourNames.Where(m=>m.IdTour.Equals(idTourRemove)))
                {
                    _context.Likes.Remove(tour); // Xóa từng tour được thích
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Add(string addTourLike)
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

            var soSanhTourTrung = _context.Likes.Where(m=>m.IdTour == addTourLike).ToList();
            if(soSanhTourTrung.Count == 0)
            {
                Like newFavorite = new Like();
                newFavorite.IdUser = users.IdUser;
                newFavorite.IdTour = addTourLike;

                _context.Add(newFavorite);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); 
        }
    }
}
