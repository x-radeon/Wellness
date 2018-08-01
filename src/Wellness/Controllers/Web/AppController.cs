using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace Wellness.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Self()
        {
            return View();
        }

        [Authorize]
        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }

}