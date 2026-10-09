using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppTemplate.Data;
using WebAppTemplate.Data.Interceptors;
using WebAppTemplate.Helpers.Email;
using WebAppTemplate.Helpers.File;
using WebAppTemplate.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).AddInterceptors(new SoftDeleteInterceptor()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddSingleton<IEmailHelper, EmailHelper>();
builder.Services.AddSingleton<IFileHelper, FileHelper>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataDbContext>();

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 3;
});
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Admin/Account/Login";
    x.LogoutPath = "/Home";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    x.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();


