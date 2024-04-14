using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace testNETCORE.Filters
{
    public class AdminAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Chưa đăng nhập, chuyển hướng đến trang đăng nhập
                context.Result = new RedirectToActionResult("LogIn", "User_", null);
                return;
            }

            // Kiểm tra quyền của người dùng
            var permissionClaim = context.HttpContext.User.FindFirst(ClaimTypes.Role);
            if (permissionClaim != null && permissionClaim.Value != "1")
            {
                // Không có quyền admin, chuyển hướng đến trang lỗi 403
                context.Result = new StatusCodeResult(403);
                return;
            }
        }
    }
}
