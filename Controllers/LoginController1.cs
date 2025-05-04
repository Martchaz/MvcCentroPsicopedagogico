using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Models;
using MvcCentroPsicopedagogico.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcCentroPsicopedagogico.Controllers
{
    public class LoginController : Controller
    {
        private readonly MvcCentroPsicopedagogicoContext _context;

        public LoginController(MvcCentroPsicopedagogicoContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var user = await _context.Usuario
                .FirstOrDefaultAsync(u => u.User == username && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.Session.SetString("User", user.User);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Credenciales inválidas";
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
