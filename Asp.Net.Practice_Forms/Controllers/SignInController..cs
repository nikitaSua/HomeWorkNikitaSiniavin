using Asp.Net.Practice_Forms.Models;
using Asp.Net.Practice_Forms.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Controllers
{
    public class Signin : Controller
    {
        private UserService userService;
        public Signin(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email,string Password)
        {
            var user = userService.GetUser(x => x.Email == Email);
            if (user!=null && user.Password==Password)
            {
                string id = Convert.ToString(user.Id);
                Response.Cookies.Append("UserId", id);
                return View();
            }
            else
            {
                return Content("wrong email or password");
            }
            
           
        }
    }
}
