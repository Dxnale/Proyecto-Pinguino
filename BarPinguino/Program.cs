using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Services;
using System.Web.Http;
using System.Web.Http.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnec"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("https://localhost:7249") // Permitir solicitudes desde localhost
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None
    });
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Registros/Login";
        options.AccessDeniedPath = "/Home/Index";
        options.LogoutPath = "/Registros/Logout";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<Correo>();
builder.Services.AddHostedService<BackupService>();



var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/Error/404");
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
