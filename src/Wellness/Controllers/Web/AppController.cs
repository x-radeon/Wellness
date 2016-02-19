using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using Microsoft.AspNet.Authorization;

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