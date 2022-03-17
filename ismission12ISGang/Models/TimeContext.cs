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

        public DbSet<Time> responses { get; set; }

        // Second line for the next table
        //public DbSet<Category> categories { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)
        {

            // Seed the values for the Category table when we build the database
            mb.Entity<Time>().HasData(

                new Time
                {
                    Month = "March",
                    Day = 12,
                    Year = 2022,
                    TimeOfDay = "8:00"

                });
            ;
        }
    }
}
