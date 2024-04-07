using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nhom8_TourDuLich.Extensions;
using nhom8_TourDuLich.Models;

namespace nhom8_TourDuLich.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly _63tinhThanhContext _context;
        public ShoppingCartController(_63tinhThanhContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            if (cart == null || !cart.Items.Any())
            {
                // Xử lý giỏ hàng trống...
                return RedirectToAction("Index", "Home");
            }
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(CartItem productId, int quantity)
        {
            // Giả sử bạn có phương thức lấy thông tin sản phẩm từ productId
            var product = await GetProductFromDatabase(productId.ID_Tour);
            var cartItem = new CartItem
            {
                ID_Tour = productId.ID_Tour,
                Price = productId.Price,
                Quantity = quantity
            };
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            cart.AddItem(cartItem);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }

        private async Task<Tour> GetProductFromDatabase(string productId)
        {
            // Truy vấn cơ sở dữ liệu để lấy thông tin sản phẩm
            var product = await _context.Tours.FirstOrDefaultAsync(h => h.Hide == false && h.TourId == productId);
            return product;
        }

        public IActionResult RemoveFromCart(CartItem carts)
        {
            var cart =
            HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart is not null)
            {
                cart.RemoveItem(carts.ID_Tour);

            }
            // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}
