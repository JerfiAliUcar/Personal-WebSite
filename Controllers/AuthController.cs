using AspNetMvcPersonalWebSite.Data;
using AspNetMvcPersonalWebSite.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetMvcPersonalWebSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin? admin, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Admin.FirstOrDefault(e => e.Mail == admin.Mail && e.Password == admin.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,admin.Id.ToString()),
                        new Claim(ClaimTypes.Email,admin.Mail),
                        new Claim(ClaimTypes.Name,"Jerfi Ali")
                    };


                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = user.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple, properties);

                    return Redirect(returnUrl != null ? returnUrl : "/");
                }

            }
            ModelState.AddModelError(string.Empty, "Email or password is incorrect!");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }

    }
}
