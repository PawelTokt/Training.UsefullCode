using MobileStore.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using MobileStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MobileStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly MobileContext _dbContext;

        public AccountController(MobileContext dbContext)
        {
            _dbContext = dbContext;
            DataBaseInitialize();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password};

                    var userRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == "user");
                    if (userRole != null)
                    {
                        user.Role = userRole;
                    }

                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect login and / or password");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect login and / or password");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        private void DataBaseInitialize()
        {
            if (_dbContext.Roles.Any()) return;

            var adminRoleName = "admin";
            var userRoleName = "user";

            var adminEmail = "admin@gmail.com";
            var adminPassword = "12345";

            var adminRole = new Role {Name = adminRoleName};
            var userRole = new Role{Name = userRoleName};

            _dbContext.Roles.Add(userRole);
            _dbContext.Roles.Add(adminRole);

            _dbContext.Users.Add(new User {Email = adminEmail, Password = adminPassword, Role = adminRole});

            _dbContext.SaveChanges();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}