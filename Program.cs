using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCentroPsicopedagogico.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de la base de datos con la conexión correcta
builder.Services.AddDbContext<MvcCentroPsicopedagogicoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")
    ?? throw new InvalidOperationException("Connection string 'DatabaseConnection' not found.")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", options =>
{
    options.LoginPath = "/Login/Login";
    options.AccessDeniedPath = "/Login/Login";

    // Expiración automática 2 minutos
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
    options.SlidingExpiration = true; // Renovación automática con cada request
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

