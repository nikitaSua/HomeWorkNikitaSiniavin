using Asp.Net.Practice_Forms.Models;
using Asp.Net.Practice_Forms.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Controllers
{
    public class AccountController : Controller
    {
        private UserService userService;
        private readonly ILogger<HomeController> _logger;
        public AccountController(UserService userService, ILogger<HomeController> logger)
        {
            this.userService = userService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/SignIn/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var user = userService.GetUser(x => x.Email == Email);
            if (user != null && user.Password == Password)
            {
                string id = Convert.ToString(user.Id);
                await Authenticate(id); // аутентификация
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Content("wrong email or password");
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("http Get Register",HttpContext.Request.QueryString );
            return View("~/Views/SignUp/Index.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Register(string FirstName, string LastName, string Email, string ConfEmail, string password, string ConfPassword)
        {
            var user = userService.GetUser(x => x.Email == Email);
            if (user != null)
            {
                return Content("такой юзер существует");
            }
            else
            {
                if (Email != ConfEmail)
                {
                    return Content("email not mach");
                }
                if (password != ConfPassword)
                {
                    return Content("password not mach");
                }
                User createdUser = new User();
                createdUser.FirstName = FirstName;
                createdUser.Email = Email;
                createdUser.LastName = LastName;
                createdUser.Password = password;
                createdUser.IsConfirmedPass = false;
                userService.AddUser(createdUser);

                var CreatedUser = userService.GetUser(x => x.Email == Email);
                await Authenticate(Convert.ToString( CreatedUser.Id));
                return RedirectToAction("Index", "Home");
            }
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
