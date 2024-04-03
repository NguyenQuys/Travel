using customer_information.Models;
using customer_information.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace customer_information.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var user = await _userRepository.GetAllAsync();
            return View(user);
        }
        public async Task<IActionResult> Display(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, User user, string option)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (option == "Nam")
            {
                user.Male = true;
            }
            else
            {
                user.Male = false;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật thông tin.");
                    return View(user);
                }
            }
            return View(user);
        }
    }
}
