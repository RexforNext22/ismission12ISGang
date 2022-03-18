// Author Ryan Pinkney, Tanner Davis, Kevin Gutierrez, Jacob Poor
// This is the model designing how we will store information about the time slots

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ismission12ISGang.Models
{
    public class Time
    {
        // Attribute to store the primary key id for each slot
        [Required]
        [Key]
        public int TimeID { get; set; }

        // Attribute to store the month
        [Required]
        public string Month { get; set; }

        // Attribute to store the day
        [Required]
        public int Day { get; set; }

        // Attribute to store the year
        [Required]
        public int Year { get; set; }

        // Attribute to store the time
        [Required]
        public string TimeOfDay { get; set; }

        // Attribute to set up the primary foreign key relationship with the person table
        //[ForeignKey("Person")]
        public int? PersonID { get; set; }
        public Person Person { get; set; }

        // Attribute to record whether the record has been reserved or not
        [Required]
        public bool bReserved { get; set; }

    }
}
