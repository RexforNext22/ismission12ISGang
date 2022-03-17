using System;
using Microsoft.EntityFrameworkCore;

namespace ismission12ISGang.Models
{
    public class TimeContext : DbContext
    {

        // Constructor
        public TimeContext(DbContextOptions<TimeContext> options) : base(options)
        {

        }

        public DbSet<Time> times { get; set; }

        // Second line for the next table
        public DbSet<Person> persons { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {

            // Seed the values for the Category table when we build the database
            _ = mb.Entity<Time>().HasData(

                new Time
                {
                    TimeID = 1,
                    Month = "March",
                    Day = 12,
                    Year = 2022,
                    TimeOfDay = "8:00",
                    PersonID = 1,
                    bReserved = false


                },
                new Time
                {
                    TimeID = 2,
                    Month = "March",
                    Day = 12,
                    Year = 2022,
                    TimeOfDay = "8:30",
                    bReserved = false


                });
            mb.Entity<Person>().HasData(

                new Person
                {
                    PersonID = 1,
                    Name = "Jacob Poor",
                    Size = 4,
                    Email = "test@test.com",
                    Phone = "800 867 5309"

                });
        }
    }
}
