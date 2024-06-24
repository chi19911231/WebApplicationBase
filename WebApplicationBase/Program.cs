using WebApplicationBase.Services;

var builder = WebApplication.CreateBuilder(args);

//新增服務(Add services to the container.)
//註冊 MVC 功能所需的服務，包括路由、控制器
builder.Services.AddControllersWithViews();
//註冊內存快取服務
//builder.Services.AddMemoryCache();

//HomeService 註冊為 Singleton 
//Singleton(單例)：只建立一個新的，每次都重複利用同一個
builder.Services.AddSingleton<IHomeService, HomeService>();

//HomeService 註冊為 Scope 
//Scoped(作用域)：每次 Request 都建立一個新的，同個 Request 重複利用同一個
//builder.Services.AddScoped<IHomeService, HomeService>();

//HomeService 註冊為 Transient 
//Transient(一次性)：每次注入都建立一個新的
//builder.Services.AddTransient<IHomeService, HomeService>();




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
