using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;
using testNETCORE.ViewModels;
using System.Security.Claims;

namespace testNETCORE.Controllers
{
    public class User_Controller : Controller
    {
        private readonly _63tinhThanhContext _context;
        public User_Controller(_63tinhThanhContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                //var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.Register.UserName);
                //if (existingUser != null)
                //{
                //    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                //    return View(viewModel);
                //}
                model.Register.Password = BCrypt.Net.BCrypt.HashPassword(model.Register.Password);
                model.Register.Permission = 0;
                model.Register.Hide = false;
                _context.Users.Add(model.Register);
                await _context.SaveChangesAsync();
                return RedirectToAction("LogIn", "User_");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserViewModel model)
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
                Register = model.Register,
            };

            if (model.Register != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.Register.PhoneNumber);
                  //Neu dung nay thi phair redirect, ma redirect thì ko trả về view thì lại lỗi
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Register.Password, user.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.PhoneNumber.ToString()),
                        new Claim(ClaimTypes.Role, user.Permission.ToString()),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Info()
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m =>m.Order).ToListAsync();
            var users = new User();

            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber.ToString() == phoneNumer.ToString());
                }
            }

            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
                Register = users,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PassData()
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
            var users = new User();

            if (User.Identity.IsAuthenticated)
            {
                string phoneNumer = User.Identity.Name;
                if (phoneNumer != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber.ToString() == phoneNumer.ToString());
                }
            }

            var viewModel = new UserViewModel
            {
                NavigationBarList = NavigationBar_Controller,
                Register = users,
            };

            TempData["transfer"] = users;
            return RedirectToAction("Detail", "Domestic_Tour_");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            var NavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();

            return View();
        }
    }
}
