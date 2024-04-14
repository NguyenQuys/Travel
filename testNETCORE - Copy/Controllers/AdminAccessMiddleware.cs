// Tạo một class middleware để kiểm tra quyền truy cập
using Microsoft.EntityFrameworkCore;
using testNETCORE.Models;

public class AdminAccessMiddleware
{
    private readonly RequestDelegate _next;

    public AdminAccessMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, JustTravelContext dbContext)
    {
        // Kiểm tra nếu URL chứa '/admin'
        if (context.Request.Path.StartsWithSegments("/admin"))
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (context.User.Identity.IsAuthenticated)
            {
                // Lấy tên người dùng từ claims
                var phoneNumber = context.User.Identity.Name;

                // Lấy thông tin người dùng từ database
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

                // Kiểm tra nếu người dùng có quyền là 0 (hoặc không phải là 1)
                if (user != null && user.Permission != 1)
                {
                    // Chuyển hướng đến trang lỗi hoặc trang thông báo không có quyền truy cập
                    context.Response.Redirect("/error/accessdenied");
                    return;
                }
            }
            else
            {
                // Nếu người dùng chưa đăng nhập, chuyển hướng đến trang đăng nhập
                context.Response.Redirect("/user/login");
                return;
            }
        }

        // Nếu không phải trang admin, tiếp tục xử lý request
        await _next(context);
    }
}

// Đăng ký Middleware
public static class MiddlewareExtensions
{
    public static void UseAdminAccessMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AdminAccessMiddleware>();
    }
}
