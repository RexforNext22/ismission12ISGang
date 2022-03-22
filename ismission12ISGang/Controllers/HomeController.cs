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
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            // Add the 3 months of dates to the database


            System.DateTime checkdate = DateTime.Now.AddDays(91);

            // Set the page
            //var oSingleTime = DbContext.times
            //    .Single(x => x.Day == checkdate.Day);

            var oSingleTimeMax = DbContext.times.OrderByDescending(u => u.TimeID).FirstOrDefault();

            // Convert the month name to an integer
            static int GetMonthNumber_From_MonthName(string monthname)
            {
                int monthNumber = 0;
                monthNumber = DateTime.ParseExact(monthname, "MMMM", CultureInfo.CurrentCulture).Month;
                return monthNumber;
            }

            // Add a month's worth
            int x = 1;

            // Debugging
            DateTime tomorrow = new DateTime(2022, 3, 23, 1, 0, 0);


            if (oSingleTimeMax != null)
            {
                DateTime date2 = new DateTime(oSingleTimeMax.Year, GetMonthNumber_From_MonthName(oSingleTimeMax.Month), oSingleTimeMax.Day, 1, 0, 0);

                if (DateTime.Compare(checkdate, date2) < 0) //change to checkdate
                {
                    x = 1000;
                }
                else
                {
                    x = 1000;
                }

            }



            while (x <= 91)
            {

                int y = 8;

                while (y < 21)
                {
                    //if (oSingleTime.Day == null)
                    //{

                    // if (oSingleTime.Month == null)

                    // if (oSingleTime.Year == null)

                    System.DateTime daysfromdate = DateTime.Now.AddDays(x);

                    Time Time = new Time();


                    Time.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(daysfromdate.Month);
                    Time.Day = daysfromdate.Day;
                    Time.Year = daysfromdate.Year;


                    if (y < 13)
                    {
                        Time.TimeOfDay = y.ToString() + ":00 a.m.";


                    }
                    else
                    {

                        Time.TimeOfDay = (y - 12).ToString() + ":00 p.m.";
                    }

                    DbContext.Add(Time);
                    DbContext.SaveChanges();
                    y = y + 1;
                }
                x = x + 1;
            }


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
            //if (ModelState.IsValid)
            //{

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
                return View("Index");
            //}
            //else
            //{
            //    // Return the same view if there is an error
            //    return View();
            //}
        }


        // Add addition functions here:

        // Get method for the edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.singleTime = DbContext.times
            .Single(x => x.PersonID == id);

            var application = DbContext.persons.Single(x => x.PersonID == id);

            return View(application);
        }


        // Post method for the edit

        [HttpPost]
        public IActionResult Edit(Person Inst, int id)
        {

            DbContext.Update(Inst);
            DbContext.SaveChanges();

            return RedirectToAction("Appointments");

        }

        // Get method for the delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointments = DbContext.persons.Single(x => x.PersonID == id);

            // Set the page
            ViewBag.singleTime = DbContext.times
                .Single(x => x.PersonID == id);

            return View(appointments);
        }

        // Post method for the delete
        [HttpPost]
        public IActionResult Delete(Person ar, int id)
        {

            // Query the record of the person that was just added
            //var oSingleRecordPerson = DbContext.persons
            //        .Single(x => x.PersonID == ar.PersonID);


            // Query the record for the time slot
            var oSingleRecord = DbContext.times
                    .Single(x => x.TimeID == id);

            //// Set the person id of the time slot record to the same person id of the person just added
            //oSingleRecord.PersonID = oSingleRecordPerson.PersonID;

            // Change the reservation status to true
            oSingleRecord.bReserved = false;
            oSingleRecord.PersonID = null;


            // Save changes back to the database
            DbContext.SaveChanges();

            //DbContext.persons.Remove(ar);
            //DbContext.SaveChanges();


            return RedirectToAction("Appointments");
        }



    }
   }
