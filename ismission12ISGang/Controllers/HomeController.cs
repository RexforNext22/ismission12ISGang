// Author Ryan Pinkney, Tanner Davis, Kevin Gutierrez, Jacob Poor
// This is our controller for the home pages

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ismission12ISGang.Models;

namespace ismission12ISGang.Controllers
{
    public class HomeController : Controller
    {

        private TimeContext DbContext { get; set; }

        public HomeController(TimeContext TimeReserve)
        {
            DbContext = TimeReserve;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }


        public IActionResult Appointments()
        {
            return View();
        }

        // call the form
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        // submit the form
        [HttpPost]
        public IActionResult Form(Person p)
        {
            // throw errors if invalid entries made
            if (ModelState.IsValid)
            {
                DbContext.Add(p);
                DbContext.SaveChanges();
                return View("Appointments", p);
            }
            else
            {
                return View(p);
            }
        }
    }
}
