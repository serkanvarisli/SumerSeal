using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SumerGidaSale.Models;

namespace ShoppingList.Controllers
{
    [Authorize]

    public class LoginController : Controller
    {
        MyDbContext _context;
        public object PageUtility { get; private set; }

        public LoginController(MyDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "UserAuthentication")]

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User model)
        {
            var user = _context.Users.FirstOrDefault(c => c.Username == model.Username && c.Password == model.Password);
            if (user != null)
            {
                await HttpContext.SignOutAsync("UserAuthentication");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.Username));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("UserAuthentication", principal, new AuthenticationProperties() { IsPersistent = false });
                Response.Cookies.Append("Username", model.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";
            }
            return View(model);
        }
     
        [AllowAnonymous]
        public IActionResult Logout()
        {
            // Oturumu sonlandırma işlemleri
            HttpContext.SignOutAsync("UserAuthentication"); // Oturumu sonlandır
            return RedirectToAction("Index", "Home"); // Anasayfaya yönlendir
        }

       
    }
}
