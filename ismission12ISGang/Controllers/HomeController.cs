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
using Microsoft.EntityFrameworkCore;

namespace ismission12ISGang.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;


        // Database configurations
        private TimeContext DbContext { get; set; }


        // Database configurations
        public HomeController(ILogger<HomeController> logger, TimeContext someName)
        {
            _logger = logger;
            DbContext = someName;
        }


        // Index route
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Sign up route
        [HttpGet]
        public IActionResult SignUp()
        {
            // Pull a list of all times from the database using tolist()
            var lstDataList = DbContext.times
                .Include(x => x.Person)
                .ToList();

            // Return the list to the screen
            return View(lstDataList);
        }


        public IActionResult Appointments()
        {
            return View();
        }

        // call the form
        [HttpGet]
        public IActionResult Form(int id)
        {
            // Set the page
            ViewBag.singleTime = DbContext.times
            .Single(x => x.TimeID == id);


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


                //Time result = (from t in DbContext.times
                //                 where t.TimeID == id
                //               select t).SingleOrDefault();

                //result.bReserved = true;

                //DbContext.SaveChanges();



                return View("Appointments", p);
            }
            else
            {
                return View(p);
            }
        }
    }
}
