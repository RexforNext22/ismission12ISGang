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

        // Configure the Home controller
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

        // Route to see the appointments view
        public IActionResult Appointments()
        {
            // Pull a list of all times from the database using tolist()
            var lstDataList = DbContext.times
                .Include(x => x.Person)
                .ToList();

            // Return the list to the screen
            return View(lstDataList);
        }

        // Route to see the form
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
        public IActionResult Form(Person p, int id)
        {
            // throw errors if invalid entries made
            if (ModelState.IsValid)
            {

                // Submit the new person to the database
                DbContext.Add(p);
                DbContext.SaveChanges();

                // Query the record of the person that was just added
                var oSingleRecordPerson = DbContext.persons
                        .Single(x => x.PersonID == p.PersonID);


                // Query the record for the time slot
                var oSingleRecord = DbContext.times
                        .Single(x => x.TimeID == id);

                // Set the person id of the time slot record to the same person id of the person just added
                oSingleRecord.PersonID = oSingleRecordPerson.PersonID;

                // Change the reservation status to true
                oSingleRecord.bReserved = true;

                // Save changes back to the database
                DbContext.SaveChanges();


                // Return the user to the homepage per the assignment instructions
                return View("Index", p);
            }
            else
            {
                // Return the same view if there is an error
                return View(p);
            }
        }


        // Add addition functions here:

        // Get method for the edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.persons = DbContext.persons.ToList();

            var application = DbContext.persons.Single(x => x.PersonID == id);

            return RedirectToAction("Form", application);
        }


        // Post method for the edit

        [HttpPost]
        public IActionResult Edit(Person Inst)
        {

            DbContext.Update(Inst);
            DbContext.SaveChanges();

            return RedirectToAction("Form");

        }

        // Get method for the delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointments = DbContext.persons.Single(x => x.PersonID == id);
            return View(appointments);
        }

        // Post method for the delete
        [HttpPost]
        public IActionResult Delete(Person ar)
        {
            DbContext.persons.Remove(ar);
            DbContext.SaveChanges();

            return RedirectToAction("Appointments");
        }



    }
   }
