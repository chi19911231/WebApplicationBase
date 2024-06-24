using WebApplicationBase.Services;

var builder = WebApplication.CreateBuilder(args);

//�s�W�A��(Add services to the container.)
//���U MVC �\��һݪ��A�ȡA�]�A���ѡB���
builder.Services.AddControllersWithViews();
//���U���s�֨��A��
//builder.Services.AddMemoryCache();

//HomeService ���U�� Singleton 
//Singleton(���)�G�u�إߤ@�ӷs���A�C�������ƧQ�ΦP�@��
builder.Services.AddSingleton<IHomeService, HomeService>();

//HomeService ���U�� Scope 
//Scoped(�@�ΰ�)�G�C�� Request ���إߤ@�ӷs���A�P�� Request ���ƧQ�ΦP�@��
//builder.Services.AddScoped<IHomeService, HomeService>();

//HomeService ���U�� Transient 
//Transient(�@����)�G�C���`�J���إߤ@�ӷs��
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
