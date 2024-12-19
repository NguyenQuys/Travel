using _2180607445_HaMinhDuc.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using _2180607445_HaMinhDuc.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Thêm DbContext vào dịch vụ và cấu hình kết nối database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();*/

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

// Thêm các dịch vụ MVC vào container
builder.Services.AddControllersWithViews();  // Thêm dịch vụ MVC cho controllers và views
builder.Services.AddScoped<IProductRepository, EFProductRepository>();  // Đăng ký repository cho sản phẩm
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();  // Đăng ký repository cho danh mục

// Thêm dịch vụ Identity vào container
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()  // Thêm dịch vụ Identity với mô hình người dùng và vai trò mặc định
    .AddDefaultTokenProviders()  // Thêm nhà cung cấp token mặc định
    .AddDefaultUI()  // Thêm giao diện người dùng mặc định
    .AddEntityFrameworkStores<ApplicationDbContext>();  // Thêm cửa hàng dữ liệu Entity Framework

// Thêm cấu hình cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddRazorPages();


// Xây dựng ứng dụng
var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Xử lý ngoại lệ trong môi trường sản xuất
    app.UseHsts();  // Kích hoạt HTTP Strict Transport Security
}
app.UseHttpsRedirection();  // Chuyển hướng HTTPS nếu được kích hoạt
app.UseStaticFiles();  // Phục vụ các file tĩnh

app.UseRouting();  // Ánh xạ các yêu cầu đến các điểm cuối

app.UseAuthentication();  // Kích hoạt xác thực
app.UseAuthorization();  // Thực thi các quy tắc ủy quyền

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Product}/{action=Index}/{id?}"
    );
});
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");  // Định nghĩa ánh xạ đường dẫn mặc định*/

app.Run();  // Khởi chạy ứng dụng
