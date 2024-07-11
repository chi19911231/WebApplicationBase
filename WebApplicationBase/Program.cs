using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<WebApplicationBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//�s�W�A��(Add services to the container.)
//���U MVC �\��һݪ��A�ȡA�]�A���ѡB���

//���U���s�֨��A��
//builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();

//���U����
//Singleton(���)�G�u�إߤ@�ӷs���A�C�������ƧQ�ΦP�@��
//builder.Services.AddSingleton<IHomeService, HomeService>();
//Scoped(�@�ΰ�)�G�C�� Request ���إߤ@�ӷs���A�P�� Request ���ƧQ�ΦP�@��
//builder.Services.AddScoped<IHomeService, HomeService>();
//Transient(�@����)�G�C���`�J���إߤ@�ӷs��
//builder.Services.AddTransient<IHomeService, HomeService>();
builder.Services.AddSingleton<IHomeService, HomeService>();
//�]DB�`�J���A�X��Singleton
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
