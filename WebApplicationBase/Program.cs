using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<WebApplicationBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//新增服務(Add services to the container.)
//註冊 MVC 功能所需的服務，包括路由、控制器

//註冊內存快取服務
//builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();

//註冊種類
//Singleton(單例)：只建立一個新的，每次都重複利用同一個
//builder.Services.AddSingleton<IHomeService, HomeService>();
//Scoped(作用域)：每次 Request 都建立一個新的，同個 Request 重複利用同一個
//builder.Services.AddScoped<IHomeService, HomeService>();
//Transient(一次性)：每次注入都建立一個新的
//builder.Services.AddTransient<IHomeService, HomeService>();
builder.Services.AddSingleton<IHomeService, HomeService>();
//因DB注入不適合用Singleton
builder.Services.AddScoped<IBaseTableService, BaseTableService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
