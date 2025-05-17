using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCentroPsicopedagogico.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using MvcCentroPsicopedagogico.Services;

var builder = WebApplication.CreateBuilder(args);

// Inyección de dependencias para servicios del chatbot
builder.Services.AddScoped<IKnowledgeBaseService, KnowledgeBaseService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<INaturalLanguageProcessor, NaturalLanguageProcessor>();
builder.Services.AddScoped<ChatBotService>();

builder.Services.AddControllers();

// Agregar el contexto de la base de datos
builder.Services.AddDbContext<MvcCentroPsicopedagogicoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")
    ?? throw new InvalidOperationException("Connection string 'DatabaseConnection' not found.")));

// Servicios de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Servicios MVC
builder.Services.AddControllersWithViews();

// Autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login/Login";
        options.AccessDeniedPath = "/Login/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

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

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
