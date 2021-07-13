using Asp.Net.Practice_Forms.Models;
using Asp.Net.Practice_Forms.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Controllers
{
    public class Signup : Controller
    {
        private UserService userService;
        public Signup(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string FirstName, string LastName,string Email, string ConfEmail, string password, string ConfPassword)
        {
            var user = userService.GetUser(x => x.Email == Email);
            if (user!=null)
            {
                return Content("такой юзер существует");
            }
            else
            {
                if (Email!= ConfEmail)
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
                return Content("User Created");
            }
        }
    }
}
