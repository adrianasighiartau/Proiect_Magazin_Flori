using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Flori.Areas.Identity.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FloriContextConnection") ?? throw new InvalidOperationException("Connection string 'FloriContextConnection' not found.");

builder.Services.AddRazorPages();

builder.Services.AddDbContext<FloriContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SiteUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FloriContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.AccessDeniedPath = "/User/PageNotAllowed";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
