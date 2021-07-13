using Asp.Net.Practice_Forms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Controllers
{
    public class ToDoController : Controller
    {
        private ToDoTaskService toDoTaskService;
        public ToDoController(ToDoTaskService toDoTaskService)
        {
            this.toDoTaskService = toDoTaskService;
        }


        [Authorize]
        public IActionResult Index()
        {
            var tasks = toDoTaskService.GetUsers(x => true);
            List<string> TaskNames = new List<string>();
            foreach (var item in tasks)
            {
                TaskNames.Add(item.Name);
            }
            if (User.Identity.IsAuthenticated)
            {
                //ViewData["Tasks"] = tasks;
                ViewBag.Countries = TaskNames;
                return View();
            }
            return Content("не аутентифицирован");
        }
    }
}
