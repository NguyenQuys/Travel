using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testNETCORE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
 AddCookie(options =>
 {
     options.Cookie.Name = "PetStoreCookie";
     options.LoginPath = "/User/Login";
 });

var connectionString =builder.Configuration.GetConnectionString("63TinhThanhConnection");
builder.Services.AddDbContext<_63tinhThanhContext>(options =>options.UseSqlServer(connectionString));

var app = builder.Build();

// Đặt trước UseRouting
app.UseRouting();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    //endpoints.MapControllerRoute(
    //    name: "dang-nhap",
    //    pattern: "dang-nhap",
    //    defaults: new { controller = "User_", action = "LogIn" });

    //endpoints.MapControllerRoute(
    //    name: "admin-page",
    //    pattern: "admin-page",
    //    defaults: new { controller = "HomeAdmin", action = "Index" });

    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin",
        defaults: new { controller = "Admin/HomeAdmin", action = "Index" });

    endpoints.MapControllerRoute(
       name: "dang-ky",
       pattern: "dang-ky",
       defaults: new { controller = "User_", action = "Register" });

    endpoints.MapControllerRoute(
        name: "admin_DTour",
        pattern: "admin_DTour",
        defaults: new { controller = "Admin/HomeAdmin", action = "List_Domestic_Tour" });

    endpoints.MapControllerRoute(
        name: "thay-doi-mat-khau",
        pattern: "thay-doi-mat-khau",
        defaults: new { controller = "User_", action = "ChangePassword" });


    //endpoints.MapControllerRoute(
    //    name: "dang-xuat",
    //    pattern: "dang-xuat",
    //    defaults: new { controller = "User_", action = "Logout" });

    endpoints.MapControllerRoute(
       name: "tour-trong-nuoc",
       pattern: "tour-trong-nuoc",
       defaults: new { controller = "Domestic_Tour_", action = "Index" });

    endpoints.MapControllerRoute(

       name: "tour-ngoai-nuoc",
       pattern: "tour-ngoai-nuoc",
       defaults: new { controller = "Overseas_Tour_", action = "Index" });

    endpoints.MapControllerRoute(
       name: "cam-nang-du-lich",
       pattern: "cam-nang-du-lich",
       defaults: new { controller = "Tour_Guide_", action = "Index" });

    endpoints.MapControllerRoute(
       name: "thong-tin-ca-nhan",
       pattern: "thong-tin-ca-nhan",
       defaults: new { controller = "User_", action = "Info" });

    endpoints.MapControllerRoute(
       name: "yeu-thich",
       pattern: "yeu-thich",
       defaults: new { controller = "Liked_", action = "Index" });

    endpoints.MapControllerRoute(
        name: "chi-tiet-tour-trong-nuoc",
        pattern: "tour-trong-nuoc/{slug}-{id}",
        defaults: new { controller = "Domestic_Tour_", action = "Detail" });

    endpoints.MapControllerRoute(
        name: "chi-tiet-tour-ngoai-nuoc",
        pattern: "tour-ngoai-nuoc/{slug}-{id}",
        defaults: new { controller = "Overseas_Tour_", action = "Detail" });

    endpoints.MapControllerRoute(
          name: "yeu-thich",
          pattern: "yeu-thich/{slug}-{id}",
          defaults: new { controller = "Liked_", action = "Detail" });

});

app.Run();
